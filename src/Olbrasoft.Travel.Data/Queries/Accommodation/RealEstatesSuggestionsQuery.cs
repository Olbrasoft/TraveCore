using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class RealEstatesSuggestionsQuery : ByLanguageIdQuery<IEnumerable<Suggestion>>
    {
        public string[] Terms { get; set; }

        public RealEstatesSuggestionsQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}