using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Querying
{
    public abstract class Query<TResult> : IQuery<TResult>
    {
        protected IQueryDispatcher QueryDispatcher { get; }

        protected Query(IQueryDispatcher queryDispatcher)
        {
            QueryDispatcher = queryDispatcher;
        }

        public TResult Execute()
        {
            return QueryDispatcher.Dispatch(this);
        }

        public Task<TResult> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return QueryDispatcher.DispatchAsync(this, cancellationToken);
        }
    }
}