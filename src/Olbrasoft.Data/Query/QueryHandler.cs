using Olbrasoft.Data.Mapping;

namespace Olbrasoft.Data.Query
{
    public abstract class QueryHandler<TQuery, TSource, TResult> : AsyncHandlerWithDependentSource<TQuery, TSource, TResult> where TQuery : IQuery<TResult>
    {
        protected QueryHandler(IHaveQueryable<TSource> ownerQueryable, IProjection projector) : base(ownerQueryable, projector)
        {
        }
    }
}