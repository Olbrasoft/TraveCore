
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Queries.Geography
{
    public class RegionsSuggestionsByTermTranslationQuery : TranslationQuery<SuggestionDto>
    {
        public RegionsSuggestionsByTermTranslationQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
        
        [StringLength(250, MinimumLength = 3)]
        public string Term { get; set; }
    }
}