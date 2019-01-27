using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class ExampleByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<object>
    {
        public ExampleByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}