using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class RoomPhotosByAccommodationIdQueryHandler : TravelQueryHandler<IPropertyContext, RoomPhotosByAccommodationIdQuery,
        IQueryable<PhotoOfAccommodation>, IEnumerable<RoomPhoto>>
    {
        public RoomPhotosByAccommodationIdQueryHandler(IPropertyContext context, IProjection projector) : base(context, projector)
        {
        }

        protected override IQueryable<PhotoOfAccommodation> GetSource()
        {
            return Context.PhotosOfAccommodations;
        }

        public override async Task<IEnumerable<RoomPhoto>> HandleAsync(RoomPhotosByAccommodationIdQuery query, CancellationToken cancellationToken)
        {
            return await ProjectionToRoomPhotos(Source, query).ToArrayAsync(cancellationToken);
        }

        protected IQueryable<RoomPhoto> ProjectionToRoomPhotos(IQueryable<PhotoOfAccommodation> photosOfAccommodations, RoomPhotosByAccommodationIdQuery query)
        {
            var photosOfRooms = photosOfAccommodations.SelectMany(p => p.ToTypesOfRooms).Select(p => p.Id);

            photosOfAccommodations = photosOfAccommodations
                .Where(p => p.AccommodationId == query.AccommodationId)
                .Where(p => photosOfRooms.Contains(p.Id));

            return ProjectTo<RoomPhoto>(photosOfAccommodations);
        }
    }
}