using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PropertiesSuggestionsQuery : ByLanguageIdQuery<IEnumerable<SuggestionDto>>
    {
        public string[] Terms { get; set; }

        public PropertiesSuggestionsQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}