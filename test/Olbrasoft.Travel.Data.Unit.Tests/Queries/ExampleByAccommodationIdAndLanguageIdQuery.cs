using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class ExampleByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<object>
    {
        public ExampleByAccommodationIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}