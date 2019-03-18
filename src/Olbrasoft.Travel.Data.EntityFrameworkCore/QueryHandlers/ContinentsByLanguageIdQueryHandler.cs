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
    public class ContinentsByLanguageIdQueryHandler : TravelQueryHandler< ContinentsByLanguageIdQuery, Subtype, IEnumerable<ContinentItem>>
    {
      
        public override async Task<IEnumerable<ContinentItem>> HandleAsync(ContinentsByLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToContinentItems(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<ContinentItem> ProjectionToContinentItems(IQueryable<Subtype> source, ContinentsByLanguageIdQuery query)
        {
            var continents = source.Where(p => p.Id == 2).SelectMany(p => p.Regions);
            var localizedContinents = continents.SelectMany(p => p.LocalizedRegions)
                .Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<ContinentItem>(localizedContinents);
        }

        public ContinentsByLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}