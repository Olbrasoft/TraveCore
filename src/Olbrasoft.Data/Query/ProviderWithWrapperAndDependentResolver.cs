using Olbrasoft.Dependence;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Query
{
    public class ProviderWithWrapperAndDependentResolver : IProvider
    {
        protected IResolver ObjectResolver { get; }

        public ProviderWithWrapperAndDependentResolver(IResolver objectResolver)
        {
            ObjectResolver = objectResolver;
        }

        public T Create<T>() where T : IQuery
        {
            return (T)ObjectResolver.Resolve(typeof(T));
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            return GetHandler(query).Handle(query);
        }

        public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        {
            return GetHandler(query).HandleAsync(query, cancellationToken);
        }

        public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
        {
            return GetHandler(query).HandleAsync(query);
        }

        private IWrapper<TResult> GetHandler<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            var resultType = typeof(TResult);

            var handlerWrapperType = typeof(WrapperWithDependentHandler<,>).MakeGenericType(queryType, resultType);

            return (IWrapper<TResult>)ObjectResolver.Resolve(handlerWrapperType);
        }

        public interface IWrapper<TResult>
        {
            TResult Handle(IQuery<TResult> query);

            Task<TResult> HandleAsync(IQuery<TResult> query);

            Task<TResult> HandleAsync(IQuery<TResult> query, CancellationToken cancellationToken);
        }

        public class WrapperWithDependentHandler<TQuery, TResult> : IWrapper<TResult> where TQuery : IQuery<TResult>
        {
            private readonly IHandler<TQuery, TResult> _handler;

            public WrapperWithDependentHandler(IHandler<TQuery, TResult> handler)
            {
                _handler = handler;
            }

            public TResult Handle(IQuery<TResult> query)
            {
                return _handler.Handle((TQuery)query);
            }

            public Task<TResult> HandleAsync(IQuery<TResult> query)
            {
                return HandleAsync(query, default(CancellationToken));
            }

            public Task<TResult> HandleAsync(IQuery<TResult> query, CancellationToken cancellationToken)
            {
                return _handler.HandleAsync((TQuery)query, cancellationToken);
            }
        }
    }
}