using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class ExampleByAccommodationIdQuery : ByAccommodationIdQuery<object>
    {
        public ExampleByAccommodationIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}