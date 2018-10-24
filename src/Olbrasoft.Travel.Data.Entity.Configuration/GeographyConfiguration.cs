namespace Olbrasoft.Travel.Data.Entity.Configuration
{
    public abstract class GeographyConfiguration<TEntity> : EntityConfigurationWithSchemaName<TEntity> where TEntity : class, IHaveDateTimeOfCreation
    {
        protected GeographyConfiguration(string tableName) : base("Geography",tableName)
        {
        }
    }
}