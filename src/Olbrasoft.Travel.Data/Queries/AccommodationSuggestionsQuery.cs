using Olbrasoft.Data.Querying;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class AccommodationSuggestionsQuery : ByLanguageIdQuery<IEnumerable<Suggestion>>
    {
        public string[] Terms { get; set; }

        public AccommodationSuggestionsQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}