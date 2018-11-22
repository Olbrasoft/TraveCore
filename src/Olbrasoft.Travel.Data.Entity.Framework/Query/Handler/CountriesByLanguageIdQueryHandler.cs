using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class CountriesByLanguageIdQueryHandler : QueryHandler<GetCountriesByLanguageId,Country,IEnumerable<CountryItem>>
    {
        public CountriesByLanguageIdQueryHandler(IHavePropertyQueryable<Country> ownerQueryable, IProjection projector) : base(ownerQueryable, projector)
        {
        }

        public override async Task<IEnumerable<CountryItem>> HandleAsync(GetCountriesByLanguageId query, CancellationToken cancellationToken)
        {
           return await ProjectionToCountryItems(Source, query, Projector).ToArrayAsync(cancellationToken);
        }


        protected IQueryable<CountryItem> ProjectionToCountryItems(IQueryable<Country> source , GetCountriesByLanguageId query, IProjection projector)
        {
            var regions = source.Select(p => p.Region);
            var localizedRegions =
                regions.SelectMany(p => p.LocalizedRegions).Where(p => p.LanguageId == query.LanguageId);
            
            return projector.ProjectTo<CountryItem>(localizedRegions);
        }

        

    }
}