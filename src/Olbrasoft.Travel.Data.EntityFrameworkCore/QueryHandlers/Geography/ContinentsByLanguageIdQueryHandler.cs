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
    public class ContinentsByLanguageIdQueryHandler : TravelQueryHandler< ContinentsByLanguageIdQuery, RegionSubtype, IEnumerable<ContinentItem>>
    {
      
        public override async Task<IEnumerable<ContinentItem>> HandleAsync(ContinentsByLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToContinentItems(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<ContinentItem> ProjectionToContinentItems(IQueryable<RegionSubtype> source, ContinentsByLanguageIdQuery query)
        {
            var continents = source.Where(p => p.Id == 2).SelectMany(p => p.Regions);
            var localizedContinents = continents.SelectMany(p => p.RegionTranslations)
                .Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<ContinentItem>(localizedContinents);
        }

        public ContinentsByLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}