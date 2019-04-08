using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Geography
{
    public class CountriesByContinentIdAndLanguageIdQueryHandler : TravelQueryHandler< CountriesByContinentIdAndLanguageIdQuery, Country,
        IEnumerable<CountryItemDto>>
    {
     

        public override async Task<IEnumerable<CountryItemDto>> HandleAsync(CountriesByContinentIdAndLanguageIdQuery query, CancellationToken token)
        {
            return await ProjectionToCountryItems(Source, query).ToArrayAsync(token);
        }

        protected IQueryable<CountryItemDto> ProjectionToCountryItems(IQueryable<Country> source, CountriesByContinentIdAndLanguageIdQuery query)
        {
            var regions = source.Select(p => p.Region);

            var countriesOfContinent =
                regions.SelectMany(p => p.ToChildRegions).Where(p => p.ToId == query.ContinentId).Select(p => p.Id);

            var localizedRegions =
                regions.Where(p => countriesOfContinent.Contains(p.Id)).SelectMany(p => p.RegionTranslations).Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<CountryItemDto>(localizedRegions);
        }

        public CountriesByContinentIdAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}