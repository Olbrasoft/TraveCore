using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Queries
{
    public interface IProvider
    {
        /// <summary>
        /// Create query
        /// </summary>
        /// <typeparam name="T">Type of concrete query</typeparam>
        /// <returns>Query</returns>
        T Create<T>() where T : IQuery;

        /// <summary>
        /// Runs the query handler registered for the given command type.
        /// If there is no handler for a given query type or there is more than one, this method will throw.
        /// </summary>
        /// <typeparam name="TResult">Type of the query</typeparam>
        /// <param name="query">Instance of the query</param>
        /// <returns>Result of the query handler</returns>
        TResult Execute<TResult>(IQuery<TResult> query);

        /// <summary>
        /// Runs the query handler registered for the given command type.
        /// If there is no handler for a given query type or there is more than one, this method will throw.
        /// </summary>
        /// <typeparam name="TResult">Type of the query</typeparam>
        /// <param name="query">Instance of the query</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>Task that resolves to a result of the query handler</returns>
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken);

        /// <summary>
        /// Runs the query handler registered for the given command type.
        /// If there is no handler for a given query type or there is more than one, this method will throw.
        /// </summary>
        /// <typeparam name="TResult">Type of the query</typeparam>
        /// <param name="query">Instance of the query</param>
        /// <returns>Task that resolves to a result of the query handler</returns>
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query);
    }
}