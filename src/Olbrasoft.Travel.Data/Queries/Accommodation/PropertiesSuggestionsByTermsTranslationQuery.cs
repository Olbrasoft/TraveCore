using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PropertiesSuggestionsByTermsTranslationQuery : TranslationQuery<IEnumerable<SuggestionDto>>
    {
        public string[] Terms { get; set; }

        public PropertiesSuggestionsByTermsTranslationQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}