using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinqKit;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class RegionsSuggestionsByTermAndLanguageIdQueryHandler : TravelQueryHandler<RegionsSuggestionsByTermAndLanguageIdQuery, Region, IEnumerable<Suggestion>>
    {
        public RegionsSuggestionsByTermAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override async Task<IEnumerable<Suggestion>> HandleAsync(RegionsSuggestionsByTermAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToSuggestions(Source, query).ToArrayAsync(cancellationToken);
        }

        private IQueryable<Suggestion> ProjectionToSuggestions(IQueryable<Region> regions, RegionsSuggestionsByTermAndLanguageIdQuery query)
        {
            //var regionsToTypes = Source.Where(p => p.ToId > 1 && p.ToId < 8);

            //var areas = regionsToTypes.Select(p => p.Region);

            //var localizedAreas = areas.SelectMany(p => p.LocalizedRegions)
            //    .Where(p => p.LanguageId == query.LanguageId);

            //localizedAreas = localizedAreas.Where(predicate);

            //localizedAreas = localizedAreas.Where(a => query.Terms.All(p => a.Name.Contains(p))).Take(6);

            //var ids = regions.Select(p => p.Region).Where(p => p.Subtype.Id > 1 && p.Subtype.Id < 8).Select(p => p.Id);

            //var localizedRegionsInOneLanguage = regions.Where(p => p.LanguageId == query.LanguageId);

            //var localizedAreas = localizedRegionsInOneLanguage.Where(p => ids.Contains(p.Id));

            regions = regions.Where(p => p.SubtypeId > 1 && p.SubtypeId < 8);

            var localizedRegions = regions.SelectMany(p => p.LocalizedRegions);

            localizedRegions = localizedRegions.Where(p => p.LanguageId == query.LanguageId);

            var predicate = query.Terms.Aggregate(PredicateBuilder.New<LocalizedRegion>(), (current, term) => current.Or(p => p.Name.Contains(term)));

            //localizedRegions = query.Terms.Aggregate(localizedRegions, (current, term) => current.Where(p => p.Name.StartsWith(term)));

            return ProjectTo<Suggestion>(localizedRegions.Where(predicate).Take(6));
        }
    }
}