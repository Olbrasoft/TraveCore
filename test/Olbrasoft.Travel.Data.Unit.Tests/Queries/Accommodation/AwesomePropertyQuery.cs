using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    internal class AwesomePropertyQuery : PropertyQuery<object>
    {
        public AwesomePropertyQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}