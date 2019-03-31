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
    public class CountriesByLanguageIdQueryHandler : TravelQueryHandler<CountriesByLanguageIdQuery, Country, IEnumerable<CountryItemDto>>
    {
     
        public override async Task<IEnumerable<CountryItemDto>> HandleAsync(CountriesByLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToCountryItems(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<CountryItemDto> ProjectionToCountryItems(IQueryable<Country> source, CountriesByLanguageIdQuery query)
        {
            var regions = source.Select(p => p.Region);
            var localizedRegions =
                regions.SelectMany(p => p.RegionTranslations).Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<CountryItemDto>(localizedRegions);
        }

        public CountriesByLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}