using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Geography
{
    public class CountriesByContinentIdAndLanguageIdQueryHandler : TravelQueryHandler< CountriesByContinentIdAndLanguageIdQuery, 
        IEnumerable<CountryItemDto>,Country>
    {
     

        public override async Task<IEnumerable<CountryItemDto>> HandleAsync(CountriesByContinentIdAndLanguageIdQuery query, CancellationToken token)
        {
            return await ProjectionToCountryItems(Entities(), query).ToArrayAsync(token);
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


        public CountriesByContinentIdAndLanguageIdQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}