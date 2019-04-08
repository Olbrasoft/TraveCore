using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Geography
{
    public class RegionsSuggestionsByTermsTranslationQuery : TranslationQuery<IEnumerable<SuggestionDto>>
    {
        public RegionsSuggestionsByTermsTranslationQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }

        public string[] Terms { get; set; }
    }
} 