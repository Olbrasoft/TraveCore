using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    internal class AwesomeByPropertyIdQuery : ByPropertyIdQuery<object>
    {
        public AwesomeByPropertyIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}