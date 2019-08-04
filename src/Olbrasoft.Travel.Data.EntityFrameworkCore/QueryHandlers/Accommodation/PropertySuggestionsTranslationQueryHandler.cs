using Microsoft.EntityFrameworkCore;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Suggestion;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PropertySuggestionsTranslationQueryHandler : TravelQueryHandler<PropertySuggestionsTranslationQuery,  IEnumerable<SuggestionDto>, PropertyTranslation>
    {
     

        public override async Task<IEnumerable<SuggestionDto>> HandleAsync(PropertySuggestionsTranslationQuery query, CancellationToken token)
        {
            return await Context.Set<PropertyTranslation>()
                .Where(p => p.LanguageId == query.LanguageId && EF.Functions.Like(p.Name, $"{query.Term}%")).Take(3)
                .Select(p => new SuggestionDto
                {
                    Id = p.Id,
                    CategoryId = (int)SuggestionCategories.Properties,
                    Category = SuggestionCategories.Properties.GetDescription(),
                    Label = p.Name
                }).ToArrayAsync(token);
        }

        public PropertySuggestionsTranslationQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}