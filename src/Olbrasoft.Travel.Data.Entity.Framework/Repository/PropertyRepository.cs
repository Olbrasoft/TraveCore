namespace Olbrasoft.Travel.Data.Entity.Framework.Repository
{
    public abstract class PropertyRepository<TEntity> : BaseRepository<TEntity> where TEntity : class
    {
        protected new IPropertyContext Context { get; }

        protected PropertyRepository(PropertyDatabaseContext context) : base(context)
        {
            Context = context;
        }
    }
}