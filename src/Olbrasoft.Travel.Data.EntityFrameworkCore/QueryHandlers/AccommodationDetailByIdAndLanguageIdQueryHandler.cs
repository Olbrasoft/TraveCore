using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class AccommodationDetailByIdAndLanguageIdQueryHandler: TravelQueryHandler< RealEstateDetailByRealEstateIdAndLanguageIdQuery, RealEstate,
        RealEstateDetail>
    {
       
        public override async Task<RealEstateDetail> HandleAsync(RealEstateDetailByRealEstateIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var localizedAccommodations = Source.SelectMany(p => p.LocalizedAccommodations);

            var accommodationDetail = await ProjectToAccommodationsDetails(localizedAccommodations, query)

                .FirstAsync(cancellationToken);

            var defaultDescription = (await ProjectToAccommodationDescriptions(localizedAccommodations, query)
                .FirstOrDefaultAsync(p => p.DescriptionId == 1, cancellationToken))?.Text;

            accommodationDetail.Description = defaultDescription;

            return accommodationDetail;
            
        }

        private IQueryable<RealEstateDescription> ProjectToAccommodationDescriptions(IQueryable<LocalizedRealEstate> source, RealEstateDetailByRealEstateIdAndLanguageIdQuery query)
        {
            var descriptions = source
                .SelectMany(p => p.RealEstate.LocalizedDescriptionsOfAccommodations)
                .Where(p => p.RealEstateId == query.AccommodationId && p.LanguageId == query.LanguageId);

            return ProjectTo<RealEstateDescription>(descriptions);
        }

        private IQueryable<RealEstateDetail> ProjectToAccommodationsDetails(IQueryable<LocalizedRealEstate> source, RealEstateDetailByRealEstateIdAndLanguageIdQuery query)
        {
            var localizedAccommodations = source.Include(p => p.RealEstate).Where(la => la.Id == query.AccommodationId && la.LanguageId == query.LanguageId);

            return ProjectTo<RealEstateDetail>(localizedAccommodations);
        }

        public AccommodationDetailByIdAndLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}