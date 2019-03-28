using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class AttributesByAccommodationIdAndLanguageIdQueryHandler : TravelQueryHandler<AttributesByRealEstateIdAndLanguageIdQuery, RealEstateToAttribute, IEnumerable<AttributeDto>>
    {
        public override async Task<IEnumerable<AttributeDto>> HandleAsync(AttributesByRealEstateIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToAttribute(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<AttributeDto> ProjectionToAttribute(IQueryable<RealEstateToAttribute> accommodationsToAttributes, AttributesByRealEstateIdAndLanguageIdQuery query)
        {
            accommodationsToAttributes = accommodationsToAttributes.Include(p => p.Attribute)
                    .Include(p => p.Attribute.LocalizedAttributes)
                    .Where(p => p.RealEstateId == query.AccommodationId)
                    .Where(p => p.LanguageId == query.LanguageId)
                    .OrderBy(p => p.Attribute.Ban)
                ;

            return ProjectTo<AttributeDto>(accommodationsToAttributes);
        }

        public AttributesByAccommodationIdAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}