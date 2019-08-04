using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public abstract class SuggestionsTranslationQuery : TranslationQuery<IEnumerable<SuggestionDto>>
    {
        [StringLength(250, MinimumLength = 3)]
        public string Term { get; set; }

        protected SuggestionsTranslationQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}