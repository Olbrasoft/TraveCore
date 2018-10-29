namespace Olbrasoft.Travel.Data.Entity.Configuration
{
    public abstract class PropertyConfiguration<TEntity> : EntityConfigurationWithSchemaName<TEntity> where TEntity : class, IHaveDateTimeOfCreation
    {
        protected PropertyConfiguration(string tableName) : base("Property",tableName)
        {
        }
    }
}