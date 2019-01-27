using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class AttributesByAccommodationIdAndLanguageIdQueryHandler : TravelQueryHandler<IGlobalizationContext, AttributesByAccommodationIdAndLanguageIdQuery,
        IQueryable<AccommodationToAttribute>, IEnumerable<Attribute>>
    {
        public AttributesByAccommodationIdAndLanguageIdQueryHandler(IGlobalizationContext context, IProjection projector) : base(context, projector)
        {
        }

        protected override IQueryable<AccommodationToAttribute> GetSource()
        {
            return Context.AccommodationsToAttributes;
        }

        public override async Task<IEnumerable<Attribute>> HandleAsync(AttributesByAccommodationIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToAttribute(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<Attribute> ProjectionToAttribute(IQueryable<AccommodationToAttribute> accommodationsToAttributes, AttributesByAccommodationIdAndLanguageIdQuery query)
        {
            accommodationsToAttributes = accommodationsToAttributes.Include(p => p.Attribute)
                    .Include(p => p.Attribute.LocalizedAttributes)
                    .Where(p => p.AccommodationId == query.AccommodationId)
                    .Where(p => p.LanguageId == query.LanguageId)
                    .OrderBy(p => p.Attribute.Ban)
                ;

            return ProjectTo<Attribute>(accommodationsToAttributes);
        }
        
    }
}