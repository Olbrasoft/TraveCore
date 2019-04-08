using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using System.Linq;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public abstract class QueryHandler<TQuery, TEntity, TResult> : Handler<TQuery, IQueryable<TEntity>, TResult>
        where TQuery : IQuery<TResult> where TEntity : class
    {
        protected TravelDbContext Context { get; }

        protected override IQueryable<TEntity> GetSource()
        {
            return Context.Set<TEntity>();
        }

        protected QueryHandler(TravelDbContext context, IProjection projector) : base(projector)
        {
            Context = context;
        }
    }
}