using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using FastMember;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Olbrasoft.Data.Entity.Framework.Bulk
{
    public class TableInfo
    {
        public string Schema { get; set; }
        public string SchemaFormatted => Schema != null ? $"[{Schema}]." : "";
        public string TableName { get; set; }
        public string FullTableName => $"{SchemaFormatted}[{TableName}]";
        public List<string> PrimaryKeys { get; set; }
        public bool HasSinglePrimaryKey { get; set; }
        public bool UpdateByPropertiesAreNullable { get; set; }

        protected string TempDbPrefix => BulkConfig.UseTempDB ? "#" : "";
        public string TempTableSuffix { get; set; }
        public string TempTableName => $"{TableName}{TempTableSuffix}";
        public string FullTempTableName => $"{SchemaFormatted}[{TempDbPrefix}{TempTableName}]";
        public string FullTempOutputTableName => $"{SchemaFormatted}[{TempDbPrefix}{TempTableName}Output]";

        public bool CreatedOutputTable => (BulkConfig.SetOutputIdentity && HasSinglePrimaryKey) || BulkConfig.CalculateStats;

        public bool InsertToTempTable { get; set; }
        public bool HasIdentity { get; set; }
        public bool HasOwnedTypes { get; set; }
        public int NumberOfEntities { get; set; }

        public BulkConfig BulkConfig { get; set; }
        public Dictionary<string, string> OutputPropertyColumnNamesDict { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> PropertyColumnNamesDict { get; set; } = new Dictionary<string, string>();
        public HashSet<string> ShadowProperties { get; set; } = new HashSet<string>();
        public Dictionary<string, ValueConverter> ConvertibleProperties { get; set; } = new Dictionary<string, ValueConverter>();
        public string TimeStampColumn { get; set; }

        public static TableInfo CreateInstance<T>(DbContext context, IList<T> entities, OperationType operationType, BulkConfig bulkConfig)
        {
            var tableInfo = new TableInfo
            {
                NumberOfEntities = entities.Count,
                BulkConfig = bulkConfig ?? new BulkConfig()
            };

            var isExplicitTransaction = context.Database.GetDbConnection().State == ConnectionState.Open;
            if (tableInfo.BulkConfig.UseTempDB && !isExplicitTransaction && operationType != OperationType.Insert)
            {
                tableInfo.BulkConfig.UseTempDB = false;
                // If BulkOps is not in explicit transaction then tempDb[#] can only be used with Insert, other Operations done with customTemp table.
                // Otherwise throws exception: 'Cannot access destination table' (gets Dropped too early because transaction ends before operation is finished)
            }

            var isDeleteOperation = operationType == OperationType.Delete;
            tableInfo.LoadData<T>(context, isDeleteOperation);
            return tableInfo;
        }

        #region Main
        public void LoadData<T>(DbContext context, bool loadOnlyPkColumn)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            if (entityType == null)
                throw new InvalidOperationException("DbContext does not contain EntitySet for Type: " + typeof(T).Name);

            var relationalData = entityType.Relational();
            Schema = relationalData.Schema ?? "dbo";
            TableName = relationalData.TableName;
            TempTableSuffix = "Temp" + Guid.NewGuid().ToString().Substring(0, 8); // 8 chars of Guid as tableNameSufix to avoid same name collision with other tables

            var areSpecifiedUpdateByProperties = BulkConfig.UpdateByProperties?.Count() > 0;
            PrimaryKeys = areSpecifiedUpdateByProperties ? BulkConfig.UpdateByProperties : entityType.FindPrimaryKey().Properties.Select(a => a.Name).ToList();
            HasSinglePrimaryKey = PrimaryKeys.Count == 1;

            var allProperties = entityType.GetProperties().AsEnumerable();

            var allNavigationProperties = entityType.GetNavigations().Where(a => a.GetTargetType().IsOwned());
            HasOwnedTypes = allNavigationProperties.Any();

            // timestamp dataType can only be set by database, that's property having [Timestamp] Attribute but keep if one with [ConcurrencyCheck]
            var allPropertiesArray = allProperties as IProperty[] ?? allProperties.ToArray();
            var timeStampProperties = allPropertiesArray.Where(a => a.IsConcurrencyToken && a.ValueGenerated == ValueGenerated.OnAddOrUpdate && a.BeforeSaveBehavior == PropertySaveBehavior.Ignore);

            var timeStampPropertiesArray = timeStampProperties as IProperty[] ?? timeStampProperties.ToArray();
            TimeStampColumn = timeStampPropertiesArray.FirstOrDefault()?.Relational().ColumnName; // expected to be only One
            var properties = allPropertiesArray.Except(timeStampPropertiesArray);

            var propertiesArray = properties as IProperty[] ?? properties.ToArray();
            OutputPropertyColumnNamesDict = propertiesArray.ToDictionary(a => a.Name, b => b.Relational().ColumnName);

            propertiesArray = propertiesArray.Where(a => a.Relational().ComputedColumnSql == null).ToArray();

            var areSpecifiedPropertiesToInclude = BulkConfig.PropertiesToInclude?.Count() > 0;
            var areSpecifiedPropertiesToExclude = BulkConfig.PropertiesToExclude?.Count() > 0;

            if (areSpecifiedPropertiesToInclude)
            {
                if (areSpecifiedUpdateByProperties) // Adds UpdateByProperties to PropertyToInclude if they are not already explicitly listed
                {
                    foreach (var updateByProperty in BulkConfig.UpdateByProperties)
                    {
                        if (!BulkConfig.PropertiesToInclude.Contains(updateByProperty))
                        {
                            BulkConfig.PropertiesToInclude.Add(updateByProperty);
                        }
                    }
                }
                else // Adds PrimaryKeys to PropertyToInclude if they are not already explicitly listed
                {
                    foreach (var primaryKey in PrimaryKeys)
                    {
                        if (!BulkConfig.PropertiesToInclude.Contains(primaryKey))
                        {
                            BulkConfig.PropertiesToInclude.Add(primaryKey);
                        }
                    }
                }
            }

            UpdateByPropertiesAreNullable = propertiesArray.Any(a => PrimaryKeys.Contains(a.Name) && a.IsNullable);

            if (areSpecifiedPropertiesToInclude || areSpecifiedPropertiesToExclude)
            {
                if (areSpecifiedPropertiesToInclude && areSpecifiedPropertiesToExclude)
                    throw new InvalidOperationException("Only one group of properties, either PropertiesToInclude or PropertiesToExclude can be specifed, specifying both not allowed.");
                if (areSpecifiedPropertiesToInclude)
                    propertiesArray = propertiesArray.Where(a => BulkConfig.PropertiesToInclude.Contains(a.Name)).ToArray();
                if (areSpecifiedPropertiesToExclude)
                    propertiesArray = propertiesArray.Where(a => !BulkConfig.PropertiesToExclude.Contains(a.Name)).ToArray();
            }

            if (loadOnlyPkColumn)
            {
                PropertyColumnNamesDict = propertiesArray.Where(a => PrimaryKeys.Contains(a.Name)).ToDictionary(a => a.Name, b => b.Relational().ColumnName);
            }
            else
            {
                PropertyColumnNamesDict = propertiesArray.ToDictionary(a => a.Name, b => b.Relational().ColumnName);
                ShadowProperties = new HashSet<string>(propertiesArray.Where(p => p.IsShadowProperty).Select(p => p.Relational().ColumnName));
                foreach (var property in propertiesArray.Where(p => p.GetValueConverter() != null))
                    ConvertibleProperties.Add(property.Relational().ColumnName, property.GetValueConverter());
            }
        }

        public void SetSqlBulkCopyConfig<T>(SqlBulkCopy sqlBulkCopy, IList<T> entities, bool setColumnMapping, Action<decimal> progress)
        {
            sqlBulkCopy.DestinationTableName = InsertToTempTable ? FullTempTableName : FullTableName;
            sqlBulkCopy.BatchSize = BulkConfig.BatchSize;
            sqlBulkCopy.NotifyAfter = BulkConfig.NotifyAfter ?? BulkConfig.BatchSize;
            sqlBulkCopy.SqlRowsCopied += (sender, e) => {
                progress?.Invoke((decimal)(e.RowsCopied * 10000 / entities.Count) / 10000); // round to 4 decimal places
            };
            sqlBulkCopy.BulkCopyTimeout = BulkConfig.BulkCopyTimeout ?? sqlBulkCopy.BulkCopyTimeout;
            sqlBulkCopy.EnableStreaming = BulkConfig.EnableStreaming;

            if (!setColumnMapping) return;

            foreach (var element in PropertyColumnNamesDict)
            {
                sqlBulkCopy.ColumnMappings.Add(element.Key, element.Value);
            }
        }
        #endregion

        #region SqlCommands
        public void CheckHasIdentity(DbContext context)
        {
            var hasIdentity = 0;
            if (HasSinglePrimaryKey)
            {
                var sqlConnection = context.Database.GetDbConnection();
                var currentTransaction = context.Database.CurrentTransaction;
                try
                {
                    if (currentTransaction == null)
                    {
                        if (sqlConnection.State != ConnectionState.Open)
                            sqlConnection.Open();
                    }
                    using (var command = sqlConnection.CreateCommand())
                    {
                        if (currentTransaction != null)
                            command.Transaction = currentTransaction.GetDbTransaction();
                        command.CommandText = SqlQueryBuilder.SelectIsIdentity(FullTableName, PropertyColumnNamesDict[PrimaryKeys[0]]);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    hasIdentity = reader[0] == DBNull.Value ? 0 : (int)reader[0];
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (currentTransaction == null)
                        sqlConnection.Close();
                }
            }
            HasIdentity = hasIdentity == 1;
        }

        public async Task CheckHasIdentityAsync(DbContext context)
        {
            int hasIdentity = 0;
            if (HasSinglePrimaryKey)
            {
                var sqlConnection = context.Database.GetDbConnection();
                var currentTransaction = context.Database.CurrentTransaction;
                try
                {
                    if (currentTransaction == null)
                    {
                        if (sqlConnection.State != ConnectionState.Open)
                            await sqlConnection.OpenAsync().ConfigureAwait(false);
                    }
                    using (var command = sqlConnection.CreateCommand())
                    {
                        if (currentTransaction != null)
                            command.Transaction = currentTransaction.GetDbTransaction();
                        command.CommandText = SqlQueryBuilder.SelectIsIdentity(FullTableName, PropertyColumnNamesDict[PrimaryKeys[0]]);
                        using (var reader = await command.ExecuteReaderAsync().ConfigureAwait(false))
                        {
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync().ConfigureAwait(false))
                                {
                                    hasIdentity = (int)reader[0];
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (currentTransaction == null)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            HasIdentity = hasIdentity == 1;
        }

        protected int GetNumberUpdated(DbContext context)
        {
            var resultParameter = new SqlParameter("@result", SqlDbType.Int) { Direction = ParameterDirection.Output };
            string sqlQueryCount = SqlQueryBuilder.SelectCountIsUpdateFromOutputTable(this);
            context.Database.ExecuteSqlCommand($"SET @result = ({sqlQueryCount});", resultParameter);
            return (int)resultParameter.Value;
        }

        protected async Task<int> GetNumberUpdatedAsync(DbContext context)
        {
            var resultParameter = new SqlParameter("@result", SqlDbType.Int) { Direction = ParameterDirection.Output };
            string sqlQueryCount = SqlQueryBuilder.SelectCountIsUpdateFromOutputTable(this);
            await context.Database.ExecuteSqlCommandAsync($"SET @result = ({sqlQueryCount});", resultParameter);
            return (int)resultParameter.Value;
        }

        #endregion

        public static string GetUniquePropertyValues<T>(T entity, List<string> propertiesNames, TypeAccessor accessor)
        {
            var result = String.Empty;
            foreach (var propertyName in propertiesNames)
            {
                result += accessor[entity, propertyName];
            }
            return result;
        }

        #region ReadProcedures
        public Dictionary<string, string> ConfigureBulkReadTableInfo(DbContext context)
        {
            InsertToTempTable = true;
            if (BulkConfig.UpdateByProperties == null || BulkConfig.UpdateByProperties.Count() == 0)
                CheckHasIdentity(context);

            var previousPropertyColumnNamesDict = PropertyColumnNamesDict;
            BulkConfig.PropertiesToInclude = PrimaryKeys;
            PropertyColumnNamesDict = PropertyColumnNamesDict.Where(a => PrimaryKeys.Contains(a.Key)).ToDictionary(i => i.Key, i => i.Value);
            return previousPropertyColumnNamesDict;
        }

        public void UpdateReadEntities<T>(IList<T> entities, IList<T> existingEntities)
        {
            var propertyNames = PropertyColumnNamesDict.Keys.ToList();
            var selectByPropertyNames = PropertyColumnNamesDict.Keys.Where(a => PrimaryKeys.Contains(a)).ToList();

            var accessor = TypeAccessor.Create(typeof(T), true);
            var existingEntitiesDict = new Dictionary<string, T>();
            string uniquePropertyValues;


            foreach (var existingEntity in existingEntities)
            {
                uniquePropertyValues = GetUniquePropertyValues(existingEntity, selectByPropertyNames, accessor);
                existingEntitiesDict.Add(uniquePropertyValues, existingEntity);
            }

            for (var i = 0; i < NumberOfEntities; i++)
            {
                var entity = entities[i];
                 uniquePropertyValues = GetUniquePropertyValues(entity, selectByPropertyNames, accessor);

                if (!existingEntitiesDict.ContainsKey(uniquePropertyValues)) continue;

                var existingEntity = existingEntitiesDict[uniquePropertyValues];

                foreach (var propertyName in propertyNames)
                {
                    accessor[entities[i], propertyName] = accessor[existingEntity, propertyName];
                }
            }
        }
        #endregion

        protected void UpdateEntitiesIdentity<T>(IList<T> entities, IList<T> entitiesWithOutputIdentity)
        {
            if (BulkConfig.PreserveInsertOrder) // Updates PK in entityList
            {
                var accessor = TypeAccessor.Create(typeof(T), true);
                for (int i = 0; i < NumberOfEntities; i++)
                    accessor[entities[i], PrimaryKeys[0]] = accessor[entitiesWithOutputIdentity[i], PrimaryKeys[0]];
            }
            else // Clears entityList and then refills it with loaded entites from Db
            {
                entities.Clear();
                ((List<T>)entities).AddRange(entitiesWithOutputIdentity);
            }
        }

        // Compiled queries created manually to avoid EF Memory leak bug when using EF with dynamic SQL:
        // https://github.com/borisdj/EFCore.BulkExtensions/issues/73
        // Once the following Issue gets fixed(expected in EF 3.0) this can be replaced with code segment: DirectQuery
        // https://github.com/aspnet/EntityFrameworkCore/issues/12905
        #region CompiledQuery
        public void LoadOutputData<T>(DbContext context, IList<T> entities) where T : class
        {
            if (BulkConfig.SetOutputIdentity && HasSinglePrimaryKey)
            {
                var sqlQuery = SqlQueryBuilder.SelectFromOutputTable(this);
                var entitiesWithOutputIdentity = QueryOutputTable<T>(context, sqlQuery).ToList();
                UpdateEntitiesIdentity(entities, entitiesWithOutputIdentity);
            }

            if (!BulkConfig.CalculateStats) return;

            SqlQueryBuilder.SelectCountIsUpdateFromOutputTable(this);

            var numberUpdated = GetNumberUpdated(context);
            BulkConfig.StatsInfo = new StatsInfo
            {
                StatsNumberUpdated = numberUpdated,
                StatsNumberInserted = entities.Count - numberUpdated
            };
        }

        public async Task LoadOutputDataAsync<T>(DbContext context, IList<T> entities) where T : class
        {
            if (BulkConfig.SetOutputIdentity && HasSinglePrimaryKey)
            {
                var sqlQuery = SqlQueryBuilder.SelectFromOutputTable(this);
                var entitiesWithOutputIdentity = await QueryOutputTableAsync<T>(context, sqlQuery).ToListAsync().ConfigureAwait(false);
                UpdateEntitiesIdentity(entities, entitiesWithOutputIdentity);
            }
            if (BulkConfig.CalculateStats)
            {
                var numberUpdated = await GetNumberUpdatedAsync(context);
                BulkConfig.StatsInfo = new StatsInfo
                {
                    StatsNumberUpdated = numberUpdated,
                    StatsNumberInserted = entities.Count - numberUpdated
                };
            }
        }
        
        protected IEnumerable<T> QueryOutputTable<T>(DbContext context, string sqlQuery) where T : class
        {
            var compiled = EF.CompileQuery(GetQueryExpression<T>(sqlQuery));
            var result = compiled(context);
            return result;
        }

        protected AsyncEnumerable<T> QueryOutputTableAsync<T>(DbContext context, string sqlQuery) where T : class
        {
            var compiled = EF.CompileAsyncQuery(GetQueryExpression<T>(sqlQuery));
            var result = compiled(context);
            return result;
        }

        public Expression<Func<DbContext, IQueryable<T>>> GetQueryExpression<T>(string sqlQuery) where T : class
        {
            Expression<Func<DbContext, IQueryable<T>>> expr = (ctx) => ctx.Set<T>().FromSql(sqlQuery).AsNoTracking();
            var ordered = OrderBy(expr, PrimaryKeys[0]);

            // ALTERNATIVELY OrderBy with DynamicLinq ('using System.Linq.Dynamic.Core;' NuGet required) that eliminates need for custom OrderBy<T> method with Expression.
            //var queryOrdered = query.OrderBy(PrimaryKeys[0]);

            return ordered;
        }

        private static Expression<Func<DbContext, IQueryable<T>>> OrderBy<T>(Expression<Func<DbContext, IQueryable<T>>> source, string ordering)
        {
            var entityType = typeof(T);
            var property = entityType.GetProperty(ordering);
            var parameter = Expression.Parameter(entityType);
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var resultExp = Expression.Call(typeof(Queryable), "OrderBy", new[] { entityType, property.PropertyType }, source.Body, Expression.Quote(orderByExp));
            return Expression.Lambda<Func<DbContext, IQueryable<T>>>(resultExp, source.Parameters);
        }
        #endregion

        // Currently not used until issue from previous segment is fixed in EFCore
        #region DirectQuery
        /*public void UpdateOutputIdentity<T>(DbContext context, IList<T> entities) where T : class
        {
            if (HasSinglePrimaryKey)
            {
                var entitiesWithOutputIdentity = QueryOutputTable<T>(context).ToList();
                UpdateEntitiesIdentity(entities, entitiesWithOutputIdentity);
            }
        }

        public async Task UpdateOutputIdentityAsync<T>(DbContext context, IList<T> entities) where T : class
        {
            if (HasSinglePrimaryKey)
            {
                var entitiesWithOutputIdentity = await QueryOutputTable<T>(context).ToListAsync().ConfigureAwait(false);
                UpdateEntitiesIdentity(entities, entitiesWithOutputIdentity);
            }
        }

        protected IQueryable<T> QueryOutputTable<T>(DbContext context) where T : class
        {
            string q = SqlQueryBuilder.SelectFromOutputTable(this);
            var query = context.Set<T>().FromSql(q);

            var queryOrdered = OrderBy(query, PrimaryKeys[0]);
            // ALTERNATIVELY OrderBy with DynamicLinq ('using System.Linq.Dynamic.Core;' NuGet required) that eliminates need for custom OrderBy<T> method with Expression.
            //var queryOrdered = query.OrderBy(PrimaryKeys[0]);

            return queryOrdered;
        }

        private static IQueryable<T> OrderBy<T>(IQueryable<T> source, string ordering)
        {
            Type entityType = typeof(T);
            PropertyInfo property = entityType.GetProperty(ordering);
            ParameterExpression parameter = Expression.Parameter(entityType);
            MemberExpression propertyAccess = Expression.MakeMemberAccess(parameter, property);
            LambdaExpression orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { entityType, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            var orderedQuery = source.Provider.CreateQuery<T>(resultExp);
            return orderedQuery;
        }*/
        #endregion
    }
}
