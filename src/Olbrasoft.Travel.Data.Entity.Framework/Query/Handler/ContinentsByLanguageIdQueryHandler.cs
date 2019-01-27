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
    public class ContinentsByLanguageIdQueryHandler : TravelQueryHandler<IGeographyContext, ContinentsByLanguageIdQuery, IQueryable<TypeOfRegion>, IEnumerable<ContinentItem>>
    {
        public ContinentsByLanguageIdQueryHandler(IGeographyContext context, IProjection projector) : base(context, projector)
        {
        }

        protected override IQueryable<TypeOfRegion> GetSource()
        {
            return Context.TypesOfRegions;
        }

        public override async Task<IEnumerable<ContinentItem>> HandleAsync(ContinentsByLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToContinentItems(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<ContinentItem> ProjectionToContinentItems(IQueryable<TypeOfRegion> source, ContinentsByLanguageIdQuery query)
        {
            var regionsToTypes = source.Where(p => p.Id == 2).SelectMany(p => p.RegionsToTypes);
            var continents = regionsToTypes.Select(p => p.Region);
            var localizedContinents = continents.SelectMany(p => p.LocalizedRegions)
                .Where(p => p.LanguageId == query.LanguageId);

            return ProjectTo<ContinentItem>(localizedContinents);
        }

       
    }
}