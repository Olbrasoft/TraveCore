using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PhotosOfAccommodationsByAccommodationIdsQueryHandler : TravelQueryHandler<PhotosOfAccommodationsByAccommodationIdsQuery, Photo, IEnumerable<RealEstatePhoto>>
    {
        public override async Task<IEnumerable<RealEstatePhoto>> HandleAsync(PhotosOfAccommodationsByAccommodationIdsQuery query, CancellationToken cancellationToken)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Source, query);

            return await projection.ToArrayAsync(cancellationToken);
        }

        private IQueryable<RealEstatePhoto> ProjectToQueryableOfAccommodationPhoto(IQueryable<Photo> source, PhotosOfAccommodationsByAccommodationIdsQuery query)
        {
            var photoOfAccommodations = from p in source
                                        where query.AccommodationIds.Contains(p.RealEstateId)
                                        select p;

            if (query.OnlyDefaultPhotos) photoOfAccommodations = photoOfAccommodations.Where(p => p.IsDefault);

            return ProjectTo<RealEstatePhoto>(photoOfAccommodations);
        }

        public PhotosOfAccommodationsByAccommodationIdsQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}