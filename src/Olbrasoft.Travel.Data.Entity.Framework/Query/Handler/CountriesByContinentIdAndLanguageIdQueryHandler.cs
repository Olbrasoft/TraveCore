using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class CountriesByContinentIdAndLanguageIdQueryHandler : TravelQueryHandler<IGeographyContext, CountriesByContinentIdAndLanguageIdQuery, IQueryable<Country>,
        IEnumerable<CountryItem>>
    {
        public CountriesByContinentIdAndLanguageIdQueryHandler(IGeographyContext context, IProjection projector) : base(context, projector)
        {
        }

        protected override IQueryable<Country> GetSource()
        {
            return Context.Countries;
        }

        public override async Task<IEnumerable<CountryItem>> HandleAsync(CountriesByContinentIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToCountryItems(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<CountryItem> ProjectionToCountryItems(IQueryable<Country> source, CountriesByContinentIdAndLanguageIdQuery query)
        {
            var regions = source.Select(p => p.Region);

            var countriesOfContinent =
                regions.SelectMany(p => p.ToChildRegions).Where(p => p.ToId == query.ContinentId).Select(p=>p.Id);

            var localizedRegions =
                regions.Where(p=>countriesOfContinent.Contains(p.Id)).SelectMany(p => p.LocalizedRegions).Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<CountryItem>(localizedRegions);
        }
    }
}