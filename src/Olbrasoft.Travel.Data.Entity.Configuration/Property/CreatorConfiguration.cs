namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public abstract class CreatorConfiguration<TEntity> : PropertyConfiguration<TEntity> where TEntity : OwnerCreatorIdAndCreator
    {
        protected CreatorConfiguration(string tableName) : base(tableName)
        {
        }
    }
}