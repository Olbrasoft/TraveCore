using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class RoomPhotosByAccommodationIdQueryHandler : TravelQueryHandler<RoomPhotosByAccommodationIdQuery,
      Photo, IEnumerable<RoomPhoto>>
    {
 

        public override async Task<IEnumerable<RoomPhoto>> HandleAsync(RoomPhotosByAccommodationIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToRoomPhotos(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<RoomPhoto> ProjectionToRoomPhotos(IQueryable<Photo> photosOfAccommodations, RoomPhotosByAccommodationIdQuery query)
        {
            var photosOfRooms = photosOfAccommodations.SelectMany(p => p.ToTypesOfRooms).Select(p => p.Id);

            photosOfAccommodations = photosOfAccommodations
                .Where(p => p.RealEstateId == query.AccommodationId)
                .Where(p => photosOfRooms.Contains(p.Id));

            return ProjectTo<RoomPhoto>(photosOfAccommodations);
        }

        public RoomPhotosByAccommodationIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}