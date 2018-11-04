using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class AccommodationDetailById : HandlerWithDependentSource<GetAccommodationDetailById, LocalizedAccommodation, AccommodationDetail>
    {
        public AccommodationDetailById(IHaveGlobalizationQueryable<LocalizedAccommodation> ownerQueryable, IProjection projector) : base(ownerQueryable, projector)
        {
        }

        public override AccommodationDetail Handle(GetAccommodationDetailById query)
        {
            var accommodationDetail = ProjectToAccommodationsDetails(Source, query).First();

            var defaultDescription = ProjectToAccommodationDescriptions(Source, query)
                .FirstOrDefault(p => p.TypeOfDescriptionId == 1)?
                .Text;

            accommodationDetail.Description = defaultDescription;

            return accommodationDetail;
        }

        public override async Task<AccommodationDetail> HandleAsync(GetAccommodationDetailById query, CancellationToken cancellationToken)
        {
            var accommodationDetail = await ProjectToAccommodationsDetails(Source, query).FirstAsync(cancellationToken);

            var defaultDescription = (await ProjectToAccommodationDescriptions(Source, query)
                .FirstOrDefaultAsync(p => p.TypeOfDescriptionId == 1, cancellationToken))?.Text;

            accommodationDetail.Description = defaultDescription;

            return accommodationDetail;
        }

        private IQueryable<AccommodationDescription> ProjectToAccommodationDescriptions(IQueryable<LocalizedAccommodation> source, GetAccommodationDetailById query)
        {
            var descriptions = source
                    .SelectMany(p => p.Accommodation.LocalizedDescriptionsOfAccommodations)
                    .Where(p => p.AccommodationId == query.Id && p.LanguageId == query.LanguageId);

            return ProjectTo<AccommodationDescription>(descriptions);
        }

        private IQueryable<AccommodationDetail> ProjectToAccommodationsDetails(IQueryable<LocalizedAccommodation> source, GetAccommodationDetailById query)
        {
            var localizedAccommodations = source.Include(p => p.Accommodation).Where(la => la.Id == query.Id && la.LanguageId == query.LanguageId);

            return ProjectTo<AccommodationDetail>(localizedAccommodations);
        }
    }
}