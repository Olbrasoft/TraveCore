using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Query
{
    public class CountriesByLanguageIdQuery : ByLanguageIdQuery<IEnumerable<CountryItem>>
    {
        public CountriesByLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}