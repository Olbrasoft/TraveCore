using Olbrasoft.Data.Query;

namespace Olbrasoft.Business.Unit.Tests
{
    internal class SomeFacade : Facade
    {
        public new IProvider QueryProvider => base.QueryProvider;

        public SomeFacade(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}