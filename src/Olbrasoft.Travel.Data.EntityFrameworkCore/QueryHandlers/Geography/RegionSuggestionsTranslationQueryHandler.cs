using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Suggestion;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Geography
{
    public class RegionSuggestionsTranslationQueryHandler : TravelQueryHandler<RegionSuggestionsTranslationQuery, Region, IEnumerable<SuggestionDto>>
    {
        public RegionSuggestionsTranslationQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }

        public override async Task<IEnumerable<SuggestionDto>> HandleAsync(RegionSuggestionsTranslationQuery query, CancellationToken token)
        {
            return await ProjectionToSuggestions(Source, query).ToArrayAsync(token);
        }

        private static IQueryable<SuggestionDto> ProjectionToSuggestions(IQueryable<Region> source, SuggestionsTranslationQuery query)
        {
            var areasCities = source.Where(p => p.SubtypeId > 1 && p.SubtypeId < 9)
                .SelectMany(p => p.RegionTranslations)
                .Where(p => p.LanguageId == query.LanguageId && EF.Functions.Like(p.Name, $"{query.Term}%")).Take(6)
                .Select(p => new SuggestionDto
                {
                    Id = p.Id,
                    Category = SuggestionCategories.AreasCities.GetDescription(),
                    Ascending = (int)SuggestionCategories.AreasCities,
                    Label = p.Name
                });

            var landmarks = source.Where(p => p.SubtypeId == 9 || p.SubtypeId == 10)
                .SelectMany(p => p.RegionTranslations)
                .Where(p => p.LanguageId == query.LanguageId && EF.Functions.Like(p.Name, $"{query.Term}%")).Take(3)
                .Select(p => new SuggestionDto
                {
                    Id = p.Id,
                    Category = SuggestionCategories.Landmarks.GetDescription(),
                    Ascending = (int)SuggestionCategories.Landmarks,
                    Label = p.Name
                });

            var airportsStations = source.Where(p => p.SubtypeId > 10)
                .SelectMany(p => p.RegionTranslations)
                .Where(p => p.LanguageId == query.LanguageId && EF.Functions.Like(p.Name, $"{query.Term}%")).Take(3)
                .Select(p => new SuggestionDto
                {
                    Id = p.Id,
                    Category = SuggestionCategories.AirportsStations.GetDescription(),
                    Ascending = (int)SuggestionCategories.AirportsStations,
                    Label = p.Name
                });

            return areasCities.Union(landmarks).Union(airportsStations);
        }
    }
}