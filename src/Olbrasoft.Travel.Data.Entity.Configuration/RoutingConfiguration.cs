namespace Olbrasoft.Travel.Data.Entity.Configuration
{
    public abstract class RoutingConfiguration<TEntity> : EntityConfigurationWithSchemaName<TEntity> where TEntity : class, IHaveDateTimeOfCreation
    {
        protected RoutingConfiguration(string tableName) : base("Routing", tableName)
        {
        }
    }
}