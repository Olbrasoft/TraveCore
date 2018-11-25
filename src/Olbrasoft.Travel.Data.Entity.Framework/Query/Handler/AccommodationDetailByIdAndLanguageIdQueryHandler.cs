using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class AccommodationDetailByIdAndLanguageIdQueryHandler: TravelQueryHandler<IPropertyContext, AccommodationDetailByIdAndLanguageIdQuery, IQueryable<Property.Accommodation>,
        AccommodationDetail>
    {
        public AccommodationDetailByIdAndLanguageIdQueryHandler(IPropertyContext context, IProjection projector) : base(context, projector)
        {

        }

        protected override IQueryable<Property.Accommodation> GetSource()
        {
            return Context.Accommodations;
        }

        public override async Task<AccommodationDetail> HandleAsync(AccommodationDetailByIdAndLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var localizedAccommodations = Source.SelectMany(p => p.LocalizedAccommodations);

            var accommodationDetail = await ProjectToAccommodationsDetails(localizedAccommodations, query).FirstAsync(cancellationToken);

            var defaultDescription = (await ProjectToAccommodationDescriptions(localizedAccommodations, query).FirstOrDefaultAsync(p => p.TypeOfDescriptionId == 1, cancellationToken))?.Text;

            accommodationDetail.Description = defaultDescription;

            return accommodationDetail;
            
        }

        private IQueryable<AccommodationDescription> ProjectToAccommodationDescriptions(IQueryable<LocalizedAccommodation> source, AccommodationDetailByIdAndLanguageIdQuery query)
        {
            var descriptions = source
                .SelectMany(p => p.Accommodation.LocalizedDescriptionsOfAccommodations)
                .Where(p => p.AccommodationId == query.Id && p.LanguageId == query.LanguageId);

            return ProjectTo<AccommodationDescription>(descriptions);
        }

        private IQueryable<AccommodationDetail> ProjectToAccommodationsDetails(IQueryable<LocalizedAccommodation> source, AccommodationDetailByIdAndLanguageIdQuery query)
        {
            var localizedAccommodations = source.Include(p => p.Accommodation).Where(la => la.Id == query.Id && la.LanguageId == query.LanguageId);

            return ProjectTo<AccommodationDetail>(localizedAccommodations);
        }
    }
}