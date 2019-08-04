using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Geography
{
    public class CountriesByLanguageIdQueryHandler : TravelQueryHandler<CountriesByLanguageIdQuery, IEnumerable<CountryItemDto>, Country>
    {
        public override async Task<IEnumerable<CountryItemDto>> HandleAsync(CountriesByLanguageIdQuery query, CancellationToken token)
        {
            return await ProjectionToCountryItems(Entities(), query).ToArrayAsync(token);
        }

        protected IQueryable<CountryItemDto> ProjectionToCountryItems(IQueryable<Country> source, CountriesByLanguageIdQuery query)
        {
            var regions = source.Select(p => p.Region);
            var localizedRegions =
                regions.SelectMany(p => p.RegionTranslations).Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<CountryItemDto>(localizedRegions);
        }

        public CountriesByLanguageIdQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}