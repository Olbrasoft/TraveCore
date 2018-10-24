namespace Olbrasoft.Travel.Data.Entity.Configuration.Geography
{
    public abstract class CreatorConfiguration<TEntity> : GeographyConfiguration<TEntity> where TEntity : OwnerCreatorIdAndCreator
    {
        protected CreatorConfiguration(string tableName) : base(tableName)
        {
        }
    }
}