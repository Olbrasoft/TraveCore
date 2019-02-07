using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Querying
{
    public abstract class QueryWithDependentProvider<TResult> : IQuery<TResult>
    {
        protected IProvider QueryProvider { get; }

        protected QueryWithDependentProvider(IProvider queryProvider)
        {
            QueryProvider = queryProvider;
        }

        public TResult Execute()
        {
            return QueryProvider.Execute(this);
        }

        public Task<TResult> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return QueryProvider.ExecuteAsync(this, cancellationToken);
        }
    }
}