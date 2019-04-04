using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PhotosOfAccommodationsByAccommodationIdsQueryHandler : TravelQueryHandler<PhotosOfAccommodationsByAccommodationIdsQuery, Photo, IEnumerable<PropertyPhotoDto>>
    {
        public override async Task<IEnumerable<PropertyPhotoDto>> HandleAsync(PhotosOfAccommodationsByAccommodationIdsQuery query, CancellationToken cancellationToken)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Source, query);

            return await projection.ToArrayAsync(cancellationToken);
        }

        private IQueryable<PropertyPhotoDto> ProjectToQueryableOfAccommodationPhoto(IQueryable<Photo> source, PhotosOfAccommodationsByAccommodationIdsQuery query)
        {
            var photoOfAccommodations = from p in source
                                        where query.AccommodationIds.Contains(p.PropertyId)
                                        select p;

            if (query.OnlyDefaultPhotos) photoOfAccommodations = photoOfAccommodations.Where(p => p.IsDefault);

            return ProjectTo<PropertyPhotoDto>(photoOfAccommodations);
        }

        public PhotosOfAccommodationsByAccommodationIdsQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}