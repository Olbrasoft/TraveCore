using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.Data.Querying
{
    public abstract class AsyncHandlerWithDependentSource<TQuery, TSource, TResult> : IHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected IQueryable<TSource> Source { get; }
        protected IProjection Projector { get; }
        
        protected AsyncHandlerWithDependentSource(IHaveQueryable<TSource> ownerQueryable, IProjection projector)
        {
            Source = ownerQueryable.Queryable;
            Projector = projector;
        }

        protected IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return Projector.ProjectTo<TDestination>(source);
        }

        public TResult Handle(TQuery query)
        {
            return HandleAsync(query).Result;
        }

        public Task<TResult> HandleAsync(TQuery query)
        {
            return HandleAsync(query, default(CancellationToken));
        }

        public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}