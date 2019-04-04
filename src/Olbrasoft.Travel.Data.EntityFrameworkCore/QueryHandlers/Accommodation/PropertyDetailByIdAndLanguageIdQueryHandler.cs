using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PropertyDetailByIdAndLanguageIdQueryHandler : TravelQueryHandler<PropertyDetailByPropertyIdAndLanguageIdQuery, Property, PropertyDetail>
    {
        public override async Task<PropertyDetail> HandleAsync(PropertyDetailByPropertyIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var localizedAccommodations = Source.SelectMany(p => p.PropertiesTranslations);

            var accommodationDetail = await ProjectToAccommodationsDetails(localizedAccommodations, query)
                .FirstAsync(cancellationToken);

            var defaultDescription = (await ProjectToAccommodationDescriptions(localizedAccommodations, query)
                .FirstOrDefaultAsync(p => p.DescriptionId == 1, cancellationToken))?.Text;

            accommodationDetail.Description = defaultDescription;

            return accommodationDetail;
        }

        private IQueryable<DescriptionDto> ProjectToAccommodationDescriptions(IQueryable<PropertyTranslation> source, PropertyDetailByPropertyIdAndLanguageIdQuery query)
        {
            var descriptions = source
                .SelectMany(p => p.Property.DescriptionsTranslations)
                .Where(p => p.PropertyId == query.PropertyId && p.LanguageId == query.LanguageId);

            return ProjectTo<DescriptionDto>(descriptions);
        }

        private IQueryable<PropertyDetail> ProjectToAccommodationsDetails(IQueryable<PropertyTranslation> source, PropertyDetailByPropertyIdAndLanguageIdQuery query)
        {
            var localizedAccommodations = source.Include(p => p.Property).Where(la => la.Id == query.PropertyId && la.LanguageId == query.LanguageId);

            return ProjectTo<PropertyDetail>(localizedAccommodations);
        }

        public PropertyDetailByIdAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}