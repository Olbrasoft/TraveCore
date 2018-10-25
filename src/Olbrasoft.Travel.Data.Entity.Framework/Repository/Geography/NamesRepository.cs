using Olbrasoft.Travel.Data.Repository.Geography;

namespace Olbrasoft.Travel.Data.Entity.Framework.Repository.Geography
{
    public class NamesRepository<TEntity> : OfName<TEntity>, INamesRepository<TEntity> where TEntity : CreationInfo<int>, IHaveName
    {
        protected new IGeographyContext Context { get; }

        public NamesRepository(GeographyDatabaseContext context) : base(context)
        {
            Context = context;
        }
    }
}