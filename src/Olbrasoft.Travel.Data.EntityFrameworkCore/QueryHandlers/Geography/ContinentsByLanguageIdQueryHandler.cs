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
    public class ContinentsByLanguageIdQueryHandler : TravelQueryHandler< ContinentsByLanguageIdQuery,  IEnumerable<ContinentItem>, RegionSubtype>
    {
      
        public override async Task<IEnumerable<ContinentItem>> HandleAsync(ContinentsByLanguageIdQuery query, CancellationToken token)
        {
            return await ProjectionToContinentItems(Entities(), query).ToArrayAsync(token);
        }

        protected IQueryable<ContinentItem> ProjectionToContinentItems(IQueryable<RegionSubtype> source, ContinentsByLanguageIdQuery query)
        {
            var continents = source.Where(p => p.Id == 2).SelectMany(p => p.Regions);
            var localizedContinents = continents.SelectMany(p => p.RegionTranslations)
                .Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<ContinentItem>(localizedContinents);
        }


        public ContinentsByLanguageIdQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}