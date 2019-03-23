using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    internal class AwesomeByRealEstateIdQuery : ByRealEstateIdQuery<object>
    {
        public AwesomeByRealEstateIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}