using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Query
{
    public class GetCountriesByLanguageId : QueryWithDependentProvider<IEnumerable<CountryItem>>
    {
        public int LanguageId { get; set; }

        public GetCountriesByLanguageId(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}