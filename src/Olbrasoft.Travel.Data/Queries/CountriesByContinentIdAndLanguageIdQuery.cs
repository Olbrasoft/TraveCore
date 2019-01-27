using System.Collections.Generic;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class CountriesByContinentIdAndLanguageIdQuery : ByLanguageIdQuery<IEnumerable<CountryItem>>
    {
        public int ContinentId { get; set; }

        public CountriesByContinentIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}