using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class AwesomeSuggestionsByTermTranslationQuery : SuggestionsTranslationQuery
    {
        public AwesomeSuggestionsByTermTranslationQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}