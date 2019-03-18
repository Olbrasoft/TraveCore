using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class AccommodationSuggestionsQueryHandler : TravelQueryHandler<AccommodationSuggestionsQuery, LocalizedRealEstate, IEnumerable<Suggestion>>
    {
        public override async Task<IEnumerable<Suggestion>> HandleAsync(AccommodationSuggestionsQuery query, CancellationToken cancellationToken)
        {
            var q = Source.Where(p => p.LanguageId == query.LanguageId);

            q = query.Terms.Aggregate(q, (current, term) => current.Where(p => p.Name.Contains(term)));

            return await ProjectTo<Suggestion>(q.Take(3)).ToArrayAsync(cancellationToken);
        }

        public AccommodationSuggestionsQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}