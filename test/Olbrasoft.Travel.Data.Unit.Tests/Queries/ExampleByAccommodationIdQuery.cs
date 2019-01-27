using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class ExampleByAccommodationIdQuery : ByAccommodationIdQuery<object>
    {
        public ExampleByAccommodationIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}