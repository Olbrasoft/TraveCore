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
    public class PhotosByPropertyIdQueryHandler : TravelQueryHandler<PhotosPropertyQuery, Photo, IEnumerable<PropertyPhotoDto>>
    {
        public override async Task<IEnumerable<PropertyPhotoDto>> HandleAsync(PhotosPropertyQuery query,
            CancellationToken cancellationToken)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Source, query);

            return await projection.ToArrayAsync(cancellationToken);
        }

        private IQueryable<PropertyPhotoDto> ProjectToQueryableOfAccommodationPhoto(
            IQueryable<Photo> source, PhotosPropertyQuery query)
        {
            var photosOfRooms = Source.SelectMany(p => p.ToTypesOfRooms).Select(p => p.Id);

            var photoOfAccommodations = source
                .Where(p => p.PropertyId == query.PropertyId)
                .Where(p => !photosOfRooms.Contains(p.Id))
                .OrderBy(p => p.IsDefault);

            return ProjectTo<PropertyPhotoDto>(photoOfAccommodations);
        }

        public PhotosByPropertyIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}