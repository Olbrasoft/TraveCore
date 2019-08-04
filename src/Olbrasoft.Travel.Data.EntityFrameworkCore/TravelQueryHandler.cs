using Olbrasoft.Mapping;
using Olbrasoft.Querying;
using Olbrasoft.Querying.Mapping.EntityFrameworkCore;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore
{
    public abstract class TravelQueryHandler<TQuery, TResult, TEntity> : QueryHandlerWithProjectorAndDbContext<TQuery, TResult, TEntity, TravelDbContext> where TQuery : IQuery<TResult> where TEntity : class

    {
        protected TravelQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}