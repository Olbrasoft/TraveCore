namespace Olbrasoft.Travel.Data.Entity.Framework.Repository
{
    public abstract class GlobalizationRepository<TEntity> : BaseRepository<TEntity> where TEntity : class
    {
        protected new IGlobalizationContext Context { get; }

        protected GlobalizationRepository(GlobalizationDatabaseContext context) : base(context)
        {
            Context = context;
        }
    }
}