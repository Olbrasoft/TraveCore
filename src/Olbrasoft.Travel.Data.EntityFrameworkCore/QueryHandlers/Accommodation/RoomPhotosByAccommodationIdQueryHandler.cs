using System.Collections.Generic;
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
    public class RoomPhotosByAccommodationIdQueryHandler : TravelQueryHandler<RoomPhotosByRealEstateIdQuery,
      Photo, IEnumerable<RoomPhotoDto>>
    {
 

        public override async Task<IEnumerable<RoomPhotoDto>> HandleAsync(RoomPhotosByRealEstateIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToRoomPhotos(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<RoomPhotoDto> ProjectionToRoomPhotos(IQueryable<Photo> photosOfAccommodations, RoomPhotosByRealEstateIdQuery query)
        {
            var photosOfRooms = photosOfAccommodations.SelectMany(p => p.ToTypesOfRooms).Select(p => p.Id);

            photosOfAccommodations = photosOfAccommodations
                .Where(p => p.RealEstateId == query.AccommodationId)
                .Where(p => photosOfRooms.Contains(p.Id));

            return ProjectTo<RoomPhotoDto>(photosOfAccommodations);
        }

        public RoomPhotosByAccommodationIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}