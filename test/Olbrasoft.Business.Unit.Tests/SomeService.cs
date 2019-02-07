using Olbrasoft.Data.Querying;

namespace Olbrasoft.Business.Unit.Tests
{
    internal class SomeService : Service
    {
        public new IProvider QueryProvider => base.QueryProvider;

        public SomeService(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}