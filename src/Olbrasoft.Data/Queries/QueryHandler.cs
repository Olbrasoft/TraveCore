using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Mapping;

namespace Olbrasoft.Data.Queries
{
    public abstract class QueryHandler<TQuery, TSource, TResult> : IHandler<TQuery, TResult> where TQuery : IQuery<TResult>
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