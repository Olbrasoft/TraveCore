using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class CountriesByLanguageIdQuery : ByLanguageIdQuery<IEnumerable<CountryItem>>
    {
        public CountriesByLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}