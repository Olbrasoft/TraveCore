using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using Olbrasoft.Data.Queries;

namespace Olbrasoft.Travel.Data.Query
{
    public class CountriesByContinentIdAndLanguageIdQuery : ByLanguageIdQuery<IEnumerable<CountryItem>>
    {
        public int ContinentId { get; set; }

        public CountriesByContinentIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}