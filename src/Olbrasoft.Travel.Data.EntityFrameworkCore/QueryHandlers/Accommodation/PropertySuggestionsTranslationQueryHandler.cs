using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Suggestion;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PropertySuggestionsTranslationQueryHandler : TravelQueryHandler<PropertySuggestionsTranslationQuery, PropertyTranslation, IEnumerable<SuggestionDto>>
    {
        public PropertySuggestionsTranslationQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override async Task<IEnumerable<SuggestionDto>> HandleAsync(PropertySuggestionsTranslationQuery query, CancellationToken token)
        {
            return await Context.Set<PropertyTranslation>()
                .Where(p => p.LanguageId == query.LanguageId && EF.Functions.Like(p.Name, $"{query.Term}%")).Take(3)
                .Select(p => new SuggestionDto
                {
                    Id = p.Id,
                    Category = SuggestionCategories.Properties.GetDescription(),
                    Label = p.Name,
                    Ascending = (int)SuggestionCategories.Properties
                }).ToArrayAsync(token);
        }
    }
}