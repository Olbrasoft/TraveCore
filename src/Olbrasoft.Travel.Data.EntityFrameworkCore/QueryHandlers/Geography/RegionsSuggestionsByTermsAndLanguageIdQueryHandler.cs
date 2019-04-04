using LinqKit;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Geography
{
    public class RegionsSuggestionsByTermsAndLanguageIdQueryHandler : TravelQueryHandler<RegionsSuggestionsByTermsTranslationQuery, Region, IEnumerable<SuggestionDto>>
    {
        public RegionsSuggestionsByTermsAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override async Task<IEnumerable<SuggestionDto>> HandleAsync(RegionsSuggestionsByTermsTranslationQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToSuggestions(Source, query).ToArrayAsync(cancellationToken);
        }

        private static IQueryable<SuggestionDto> ProjectionToSuggestions(IQueryable<Region> regions, RegionsSuggestionsByTermsTranslationQuery query)
        {
            var predicate = query.Terms.Aggregate(PredicateBuilder.New<RegionTranslation>(), (current, term) => current.Or(p => p.Name.Contains(term)));
            
            var areasCitiesQueryable = regions.Where(p => p.SubtypeId > 1 && p.SubtypeId < 9)
                .SelectMany(p => p.RegionTranslations).Where(p => p.LanguageId == query.LanguageId).Where(predicate)
                .Take(6).Select(p => new { p.Id, p.Name, Category = "Cities/Areas", Ascending = 1 });

            var landmarksQueryable = regions.Where(p => p.SubtypeId == 9 || p.SubtypeId == 10)
                .SelectMany(p => p.RegionTranslations).Where(p => p.LanguageId == query.LanguageId).Where(predicate)
                .Take(3).Select(p => new { p.Id, p.Name, Category = "Landmarks", Ascending = 3 });

            //Airports/Stations
            var airportsStationsQueryable = regions.Where(p => p.SubtypeId > 10)
                .SelectMany(p => p.RegionTranslations).Where(p => p.LanguageId == query.LanguageId).Where(predicate)
                .Take(3).Select(p => new { p.Id, p.Name, Category = "Airports/Stations", Ascending = 4 });

            return areasCitiesQueryable.Union(landmarksQueryable).Union(airportsStationsQueryable).Select(p => new SuggestionDto
            {
                Id = p.Id,
                Label = p.Name,
                Category = p.Category,
                Ascending = p.Ascending
            });
        }
    }
}