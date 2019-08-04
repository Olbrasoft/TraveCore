using Microsoft.Extensions.DependencyInjection;
using System;

namespace Olbrasoft.Querying.DependencyInjection.Microsoft
{
    public class QueryFactory : BaseQueryFactory
    {
        private readonly IServiceScopeFactory _factory;

        private IServiceProvider _provider;

        protected IServiceProvider Provider => _provider ?? (_provider = _factory.CreateScope().ServiceProvider);

        public QueryFactory(IServiceScopeFactory factory)
        {
            _factory = factory;
        }

        public override T CreateQuery<T>()
        {
            return Provider.GetService<T>();
        }
    }
}