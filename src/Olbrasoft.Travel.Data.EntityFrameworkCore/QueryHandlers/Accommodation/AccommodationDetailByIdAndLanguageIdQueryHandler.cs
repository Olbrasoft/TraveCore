using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class AccommodationDetailByIdAndLanguageIdQueryHandler : TravelQueryHandler<RealEstateDetailByRealEstateIdAndLanguageIdQuery, RealEstate,
        PropertyDetail>
    {
        public override async Task<PropertyDetail> HandleAsync(RealEstateDetailByRealEstateIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var localizedAccommodations = Source.SelectMany(p => p.LocalizedAccommodations);

            var accommodationDetail = await ProjectToAccommodationsDetails(localizedAccommodations, query)

                .FirstAsync(cancellationToken);

            var defaultDescription = (await ProjectToAccommodationDescriptions(localizedAccommodations, query)
                .FirstOrDefaultAsync(p => p.DescriptionId == 1, cancellationToken))?.Text;

            accommodationDetail.Description = defaultDescription;

            return accommodationDetail;
        }

        private IQueryable<DescriptionDto> ProjectToAccommodationDescriptions(IQueryable<LocalizedRealEstate> source, RealEstateDetailByRealEstateIdAndLanguageIdQuery query)
        {
            var descriptions = source
                .SelectMany(p => p.RealEstate.LocalizedDescriptionsOfAccommodations)
                .Where(p => p.RealEstateId == query.AccommodationId && p.LanguageId == query.LanguageId);

            return ProjectTo<DescriptionDto>(descriptions);
        }

        private IQueryable<PropertyDetail> ProjectToAccommodationsDetails(IQueryable<LocalizedRealEstate> source, RealEstateDetailByRealEstateIdAndLanguageIdQuery query)
        {
            var localizedAccommodations = source.Include(p => p.RealEstate).Where(la => la.Id == query.AccommodationId && la.LanguageId == query.LanguageId);

            return ProjectTo<PropertyDetail>(localizedAccommodations);
        }

        public AccommodationDetailByIdAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}