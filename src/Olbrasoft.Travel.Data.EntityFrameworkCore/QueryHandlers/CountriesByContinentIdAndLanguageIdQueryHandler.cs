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
    public class CountriesByContinentIdAndLanguageIdQueryHandler : TravelQueryHandler< CountriesByContinentIdAndLanguageIdQuery, Country,
        IEnumerable<CountryItem>>
    {
     

        public override async Task<IEnumerable<CountryItem>> HandleAsync(CountriesByContinentIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToCountryItems(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<CountryItem> ProjectionToCountryItems(IQueryable<Country> source, CountriesByContinentIdAndLanguageIdQuery query)
        {
            var regions = source.Select(p => p.Region);

            var countriesOfContinent =
                regions.SelectMany(p => p.ToChildRegions).Where(p => p.ToId == query.ContinentId).Select(p => p.Id);

            var localizedRegions =
                regions.Where(p => countriesOfContinent.Contains(p.Id)).SelectMany(p => p.LocalizedRegions).Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<CountryItem>(localizedRegions);
        }

        public CountriesByContinentIdAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}