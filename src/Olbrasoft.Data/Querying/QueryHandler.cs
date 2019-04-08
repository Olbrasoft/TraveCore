using Olbrasoft.Data.Mapping;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Querying
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        public TResult Handle(TQuery query)
        {
            return HandleAsync(query).Result;
        }

        public Task<TResult> HandleAsync(TQuery query)
        {
            return HandleAsync(query, default);
        }

        public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken token);
    }

    public abstract class QueryHandler<TQuery, TSource, TResult> : QueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private TSource _source;
        private IProjection Projector { get; }

        protected TSource Source
        {
            get
            {
                if (_source == null) _source = GetSource();
                return _source;
            }
        }

        protected QueryHandler(IProjection projector)
        {
            Projector = projector;
        }

        protected abstract TSource GetSource();

        protected IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source)
        {
            return Projector.ProjectTo<TDestination>(source);
        }
    }
}