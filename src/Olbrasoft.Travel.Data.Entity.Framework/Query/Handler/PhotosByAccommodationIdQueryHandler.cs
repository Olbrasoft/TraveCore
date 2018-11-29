using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class PhotosByAccommodationIdQueryHandler : TravelQueryHandler<IPropertyContext,
        PhotosByAccommodationIdQuery,
        IQueryable<PhotoOfAccommodation>, IEnumerable<AccommodationPhoto>>
    {
        public PhotosByAccommodationIdQueryHandler(IPropertyContext context, IProjection projector) : base(context,
            projector)
        {
        }

        protected override IQueryable<PhotoOfAccommodation> GetSource()
        {
            return Context.PhotosOfAccommodations;
        }

        public override async Task<IEnumerable<AccommodationPhoto>> HandleAsync(PhotosByAccommodationIdQuery query,
            CancellationToken cancellationToken)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Source, query);

            return await projection.ToArrayAsync(cancellationToken);
        }

        private IQueryable<AccommodationPhoto> ProjectToQueryableOfAccommodationPhoto(
            IQueryable<PhotoOfAccommodation> source, PhotosByAccommodationIdQuery query)
        {
            var photosOfRooms = Source.SelectMany(p => p.ToTypesOfRooms).Select(p => p.Id);

            var photoOfAccommodations = source
                .Where(p => p.AccommodationId == query.AccommodationId)
                .Where(p => !photosOfRooms.Contains(p.Id))
                .OrderBy(p => p.IsDefault);

            return ProjectTo<AccommodationPhoto>(photoOfAccommodations);
        }
    }
}