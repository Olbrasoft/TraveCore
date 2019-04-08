using LinqKit;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Suggestion;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PropertiesSuggestionsByTermsTranslationQueryHandler : TravelQueryHandler<PropertiesSuggestionsByTermsTranslationQuery, PropertyTranslation, IEnumerable<SuggestionDto>>
    {
        public override async Task<IEnumerable<SuggestionDto>> HandleAsync(PropertiesSuggestionsByTermsTranslationQuery query, CancellationToken token)
        {
            var predicate = query.Terms.Aggregate(PredicateBuilder.New<PropertyTranslation>(),
                (current, term) => current.Or(propertyTranslation => propertyTranslation.Name.StartsWith(term)));

            const SuggestionCategories propertySuggestion = SuggestionCategories.Properties;

            return await Source.Where(propertyTranslation => propertyTranslation.LanguageId == query.LanguageId)
                .Where(predicate).Take(3)
                .Select(p => new SuggestionDto
                {
                    Id = p.Id, Label = p.Name, Category = propertySuggestion.GetDescription(),
                    Ascending = (int) propertySuggestion
                }).ToArrayAsync(token).ConfigureAwait(false);
        }

        public PropertiesSuggestionsByTermsTranslationQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}