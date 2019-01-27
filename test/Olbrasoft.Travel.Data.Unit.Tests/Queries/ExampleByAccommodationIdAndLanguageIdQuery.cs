using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class ExampleByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<object>
    {
        public ExampleByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}