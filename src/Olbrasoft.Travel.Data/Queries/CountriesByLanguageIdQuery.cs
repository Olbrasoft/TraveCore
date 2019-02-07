using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class CountriesByLanguageIdQuery : ByLanguageIdQuery<IEnumerable<CountryItem>>
    {
        public CountriesByLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}