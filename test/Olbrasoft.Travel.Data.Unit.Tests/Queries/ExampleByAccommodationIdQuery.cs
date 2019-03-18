using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class ExampleByAccommodationIdQuery : ByAccommodationIdQuery<object>
    {
        public ExampleByAccommodationIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}