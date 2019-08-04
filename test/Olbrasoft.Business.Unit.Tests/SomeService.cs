using Olbrasoft.Querying;

namespace Olbrasoft.Business.Unit.Tests
{
    internal class SomeService : Service
    {
        public new IQueryFactory QueryFactory => base.QueryFactory;

        public SomeService(IQueryFactory queryFactory) : base(queryFactory)
        {
        }
    }
}