using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Mapping;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PhotosByPropertyIdQueryHandler : TravelQueryHandler<PhotosPropertyQuery, IEnumerable<PropertyPhotoDto>,Photo>
    {
        public override async Task<IEnumerable<PropertyPhotoDto>> HandleAsync(PhotosPropertyQuery query,
            CancellationToken token)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Entities(), query);

            return await projection.ToArrayAsync(token);
        }

        private IQueryable<PropertyPhotoDto> ProjectToQueryableOfAccommodationPhoto(
            IQueryable<Photo> source, PhotosPropertyQuery query)
        {
            var photosOfRooms = source.SelectMany(p => p.ToTypesOfRooms).Select(p => p.Id);

            var photoOfAccommodations = source
                .Where(p => p.PropertyId == query.PropertyId)
                .Where(p => !photosOfRooms.Contains(p.Id))
                .OrderBy(p => p.IsDefault);

            return ProjectTo<PropertyPhotoDto>(photoOfAccommodations);
        }


        public PhotosByPropertyIdQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}