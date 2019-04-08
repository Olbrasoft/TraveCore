using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.Queries.Geography
{
    public class CountriesByContinentIdAndLanguageIdQuery : TranslationQuery<IEnumerable<CountryItemDto>>
    {
        public int ContinentId { get; set; }

        public CountriesByContinentIdAndLanguageIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}