using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Query;
using Attribute = Olbrasoft.Travel.Data.Transfer.Object.Attribute;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class AttributesByAccommodationIdAndLanguageId : AsyncHandlerWithDependentSource<GetAttributesByAccommodationIdAndLanguageId, AccommodationToAttribute, IEnumerable<Attribute>>
    {
        public AttributesByAccommodationIdAndLanguageId(IHaveGlobalizationQueryable<AccommodationToAttribute> ownerQueryable, IProjection projector) : base(ownerQueryable, projector)
        {
        }

        public override async Task<IEnumerable<Attribute>> HandleAsync(GetAttributesByAccommodationIdAndLanguageId query, CancellationToken cancellationToken)
        {
            return await ProjectionToAttribute(Source, query, Projector).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<Attribute> ProjectionToAttribute(IQueryable<AccommodationToAttribute> accommodationsToAttributes, GetAttributesByAccommodationIdAndLanguageId query, IProjection projector)
        {
            accommodationsToAttributes = accommodationsToAttributes
                .Include(p => p.Attribute)
                .Include(p => p.Attribute.LocalizedAttributes)
                .Where(p => p.AccommodationId == query.AccommodationId)
                .Where(p => p.LanguageId == query.LanguageId)
                    .OrderBy(p => p.Attribute.Ban)
                ;

            return projector.ProjectTo<Attribute>(accommodationsToAttributes);
        }
    }
}