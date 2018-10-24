namespace Olbrasoft.Travel.Data.Entity.Configuration
{
    public abstract class IdentityConfiguration<TEntity> : EntityConfigurationWithSchemaName<TEntity> where TEntity : class, IHaveDateTimeOfCreation
    {
        protected IdentityConfiguration(string tableName) : base("Identity", tableName)
        {
        }
    }
}