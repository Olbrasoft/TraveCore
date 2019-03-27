using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Geography
{
    public class CountriesByLanguageIdQueryHandler : TravelQueryHandler<CountriesByLanguageIdQuery, Country, IEnumerable<CountryItem>>
    {
     
        public override async Task<IEnumerable<CountryItem>> HandleAsync(CountriesByLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToCountryItems(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<CountryItem> ProjectionToCountryItems(IQueryable<Country> source, CountriesByLanguageIdQuery query)
        {
            var regions = source.Select(p => p.Region);
            var localizedRegions =
                regions.SelectMany(p => p.LocalizedRegions).Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<CountryItem>(localizedRegions);
        }

        public CountriesByLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}