using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Geography
{
    public class CountriesByContinentIdAndLanguageIdQuery : ByLanguageIdQuery<IEnumerable<CountryItem>>
    {
        public int ContinentId { get; set; }

        public CountriesByContinentIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}