using Microsoft.Extensions.DependencyInjection;
using System;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryExecutorFactory : BaseQueryExecutorFactory
    {
        private IServiceProvider _provider;
        private readonly IServiceScopeFactory _factory;

        protected IServiceProvider Provider => _provider ?? (_provider = _factory.CreateScope().ServiceProvider);

        public QueryExecutorFactory(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public override IQueryExecutor<TResult> Get<TResult>(Type executorType)
        {
            return (IQueryExecutor<TResult>)Provider.GetService(executorType);
        }
    }
}