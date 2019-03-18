using Olbrasoft.Data.Querying;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class SuggestionsOfRegionByTermAndLanguageIdQuery : ByLanguageIdQuery<IEnumerable<Suggestion>>
    {
        public SuggestionsOfRegionByTermAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }

        public string[] Terms { get; set; }
    }
}