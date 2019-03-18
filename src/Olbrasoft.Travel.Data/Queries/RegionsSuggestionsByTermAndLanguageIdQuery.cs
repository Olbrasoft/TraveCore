using Olbrasoft.Data.Querying;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class RegionsSuggestionsByTermAndLanguageIdQuery : ByLanguageIdQuery<IEnumerable<Suggestion>>
    {
        public RegionsSuggestionsByTermAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }

        public string[] Terms { get; set; }
    }
}