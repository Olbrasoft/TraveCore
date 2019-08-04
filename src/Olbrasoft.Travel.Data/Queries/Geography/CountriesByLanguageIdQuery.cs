using System.Collections.Generic;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.Queries.Geography
{
    public class CountriesByLanguageIdQuery : TranslationQuery<IEnumerable<CountryItemDto>>
    {
        public CountriesByLanguageIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}