using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Attribute = Olbrasoft.Travel.Data.Transfer.Objects.Attribute;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class AttributesByAccommodationIdAndLanguageIdQueryHandler : TravelQueryHandler<AttributesByAccommodationIdAndLanguageIdQuery, RealEstateToAttribute, IEnumerable<Attribute>>
    {
        public override async Task<IEnumerable<Attribute>> HandleAsync(AttributesByAccommodationIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToAttribute(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<Attribute> ProjectionToAttribute(IQueryable<RealEstateToAttribute> accommodationsToAttributes, AttributesByAccommodationIdAndLanguageIdQuery query)
        {
            accommodationsToAttributes = accommodationsToAttributes.Include(p => p.Attribute)
                    .Include(p => p.Attribute.LocalizedAttributes)
                    .Where(p => p.RealEstateId == query.AccommodationId)
                    .Where(p => p.LanguageId == query.LanguageId)
                    .OrderBy(p => p.Attribute.Ban)
                ;

            return ProjectTo<Attribute>(accommodationsToAttributes);
        }

        public AttributesByAccommodationIdAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}