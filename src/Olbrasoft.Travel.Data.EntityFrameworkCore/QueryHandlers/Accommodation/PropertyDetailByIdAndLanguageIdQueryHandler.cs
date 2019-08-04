using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PropertyDetailByIdAndLanguageIdQueryHandler : TravelQueryHandler<PropertyDetailByPropertyIdAndLanguageIdQuery,  PropertyDetail,Property>
    {
        public override async Task<PropertyDetail> HandleAsync(PropertyDetailByPropertyIdAndLanguageIdQuery query, CancellationToken token)
        {
            var localizedAccommodations = Entities().SelectMany(p => p.PropertiesTranslations);

            var accommodationDetail = await ProjectToAccommodationsDetails(localizedAccommodations, query)
                .FirstAsync(token);

            var defaultDescription = (await ProjectToAccommodationDescriptions(localizedAccommodations, query)
                .FirstOrDefaultAsync(p => p.DescriptionId == 1, token))?.Text;

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


        public PropertyDetailByIdAndLanguageIdQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}