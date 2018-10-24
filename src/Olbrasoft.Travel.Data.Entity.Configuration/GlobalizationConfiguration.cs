namespace Olbrasoft.Travel.Data.Entity.Configuration
{
    public abstract class GlobalizationConfiguration<TEntity> : EntityConfigurationWithSchemaName<TEntity> where TEntity : class, IHaveDateTimeOfCreation
    {
        protected GlobalizationConfiguration(string tableName ) : base("Globalization",tableName)
        {
        }
    }
}