using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Olbrasoft.Mapping;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class AttributesByPropertyIdAndLanguageIdQueryHandler : TravelQueryHandler<AttributesByPropertyIdAndLanguageIdQuery,  IEnumerable<AttributeDto>, PropertyToAttribute>
    {
        public override async Task<IEnumerable<AttributeDto>> HandleAsync(AttributesByPropertyIdAndLanguageIdQuery query, CancellationToken token)
        {
            return await ProjectionToAttribute(Entities(), query).ToArrayAsync(token);
        }

        protected IQueryable<AttributeDto> ProjectionToAttribute(IQueryable<PropertyToAttribute> accommodationsToAttributes, AttributesByPropertyIdAndLanguageIdQuery query)
        {
            accommodationsToAttributes = accommodationsToAttributes.Include(p => p.Attribute)
                    .Include(p => p.Attribute.LocalizedAttributes)
                    .Where(p => p.PropertyId == query.PropertyId)
                    .Where(p => p.LanguageId == query.LanguageId)
                    .OrderBy(p => p.Attribute.Ban);

            return ProjectTo<AttributeDto>(accommodationsToAttributes);
        }
     
        public AttributesByPropertyIdAndLanguageIdQueryHandler(IProjection projector ,TravelDbContext context) : base( projector, context)
        {
        }
    }
}