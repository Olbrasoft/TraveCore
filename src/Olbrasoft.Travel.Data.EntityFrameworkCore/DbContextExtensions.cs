﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Entity.Framework.Bulk;
using static System.Threading.Tasks.Task;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore
{
    public static class DbContextExtensions
    {
        /// <summary>
        ///     Returns the name of the specified property of the specified type.
        /// </summary>
        /// <typeparam name="T">
        ///     The type the property is a member of.
        /// </typeparam>
        /// <param name="property">
        ///     The property.
        /// </param>
        /// <returns>
        ///     The property name.
        /// </returns>
        public static string GetPropertyName<T>(Expression<Func<T, object>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression expression)
            {
                var unaryExpression = expression;
                memberExpression = (MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (MemberExpression)(lambda.Body);
            }

            return (memberExpression.Member as PropertyInfo)?.Name;
        }

        public static void BulkUpdate<T>(this DbContext context, IEnumerable<T> entities, Action<EventArgs> onSaved, int batchSize = 90000, params Expression<Func<T, object>>[] ignoreProperties) where T : class
        {
            var batchesToUpdate = entities.SplitToEnumerableOfList(batchSize);
            var ignoreColumnsUpdate = new HashSet<string>(ignoreProperties.Select(GetPropertyName));
            const string creatorIdColumnName = "CreatorId";

            if (!ignoreColumnsUpdate.Contains(creatorIdColumnName)) ignoreColumnsUpdate.Add(creatorIdColumnName);

            if (batchSize == 90000)
            {
                batchSize = 45000;
            }

            foreach (var batch in batchesToUpdate)
            {
                context.BulkUpdate(batch, new BulkConfig
                {
                    BatchSize = batchSize,
                    BulkCopyTimeout = 480,
                    IgnoreColumns = new HashSet<string>(new[] { "Created" }),
                    IgnoreColumnsUpdate = ignoreColumnsUpdate
                });
                onSaved(EventArgs.Empty);
            }
        }

        public static void BulkInsert<T>(this DbContext context, IEnumerable<T> entities, Action<EventArgs> onSaved, int batchSize = 90000, params Expression<Func<T, object>>[] ignoreProperties) where T : class
        {
            var batchesToInsert = entities.SplitToEnumerableOfList(batchSize);
            var ignoreColumnsInsert = new HashSet<string>(ignoreProperties.Select(GetPropertyName));

            const string createDateColumn = "Created";
            if (!ignoreColumnsInsert.Contains(createDateColumn)) ignoreColumnsInsert.Add(createDateColumn);

            if (batchSize == 90000)
            {
                batchSize = 45000;
            }

            foreach (var batch in batchesToInsert)
            {
                context.BulkInsert(batch,
                     new BulkConfig
                     {
                         BatchSize = batchSize,
                         BulkCopyTimeout = 480,
                         IgnoreColumns = ignoreColumnsInsert
                     });

                onSaved(EventArgs.Empty);
            }
        }

        public static void BulkInsert<T>(this DbContext context, IEnumerable<T> entities, Action<EventArgs> onSaved, params Expression<Func<T, object>>[] ignoreProperties) where T : class
        {
            BulkInsert(context, entities, onSaved, 90000, ignoreProperties);
        }
    }
}