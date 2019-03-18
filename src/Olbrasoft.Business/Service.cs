using Olbrasoft.Data.Querying;

namespace Olbrasoft.Business
{
    public abstract class Service
    {
        protected IQueryFactory QueryFactory { get; }

        protected Service( IQueryFactory queryFactory)
        {
            QueryFactory = queryFactory;
        }
    }
}