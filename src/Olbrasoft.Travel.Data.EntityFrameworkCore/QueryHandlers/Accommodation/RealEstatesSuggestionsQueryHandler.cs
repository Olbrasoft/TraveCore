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

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class RealEstatesSuggestionsQueryHandler : TravelQueryHandler<RealEstatesSuggestionsQuery, PropertyTranslation, IEnumerable<SuggestionDto>>
    {
        public override async Task<IEnumerable<Transfer.Objects.SuggestionDto>> HandleAsync(RealEstatesSuggestionsQuery query, CancellationToken cancellationToken)
        {
            var predicate = query.Terms.Aggregate(PredicateBuilder.New<PropertyTranslation>(), (current, term) => current.Or(p => p.Name.Contains(term)));

            return await Source.Where(p => p.LanguageId == query.LanguageId).Where(predicate).Take(3)
                .Select(p => new SuggestionDto
                {
                    Id = p.Id,
                    Label = p.Name,
                    Category = "Properties",
                    Ascending = 2
                }).ToArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        public RealEstatesSuggestionsQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}