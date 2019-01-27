using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class CountriesByLanguageIdQueryHandler : TravelQueryHandler<IGeographyContext, CountriesByLanguageIdQuery, IQueryable<Country>, IEnumerable<CountryItem>>
    {
        public CountriesByLanguageIdQueryHandler(IGeographyContext context, IProjection projector) : base(context, projector)
        {
        }

        protected override IQueryable<Country> GetSource()
        {
            return Context.Countries;
        }

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
    }
}