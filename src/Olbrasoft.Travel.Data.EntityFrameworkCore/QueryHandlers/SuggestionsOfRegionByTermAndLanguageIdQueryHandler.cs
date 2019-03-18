using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class SuggestionsOfRegionByTermAndLanguageIdQueryHandler : TravelQueryHandler<SuggestionsOfRegionByTermAndLanguageIdQuery, LocalizedRegion,
        IEnumerable<Suggestion>>
    {
        public SuggestionsOfRegionByTermAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
        
        public override async Task<IEnumerable<Suggestion>> HandleAsync(SuggestionsOfRegionByTermAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToSuggestions(Source, query).ToArrayAsync(cancellationToken);
        }

        private IQueryable<Suggestion> ProjectionToSuggestions(IQueryable<LocalizedRegion> localizedRegions, SuggestionsOfRegionByTermAndLanguageIdQuery query)
        {
            //var regionsToTypes = Source.Where(p => p.ToId > 1 && p.ToId < 8);

            //var areas = regionsToTypes.Select(p => p.Region);

            //var localizedAreas = areas.SelectMany(p => p.LocalizedRegions)
            //    .Where(p => p.LanguageId == query.LanguageId);

            //localizedAreas = localizedAreas.Where(predicate);

            //localizedAreas = localizedAreas.Where(a => query.Terms.All(p => a.Name.Contains(p))).Take(6);

            var ids = localizedRegions.Select(p => p.Region).Where(p => p.Subtype.Id > 1 && p.Subtype.Id < 8).Select(p => p.Id);

            var localizedRegionsInOneLanguage = localizedRegions.Where(p => p.LanguageId == query.LanguageId);

            var localizedAreas = localizedRegionsInOneLanguage.Where(p => ids.Contains(p.Id));

            localizedAreas = query.Terms.Aggregate(localizedAreas, (current, term) => current.Where(p => p.Name.StartsWith(term) || p.Name.Contains(term)));

            return ProjectTo<Suggestion>(localizedAreas.Take(6));
        }

        
    }
}