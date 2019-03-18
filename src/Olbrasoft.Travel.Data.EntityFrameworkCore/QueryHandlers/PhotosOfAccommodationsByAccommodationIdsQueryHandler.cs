using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class PhotosOfAccommodationsByAccommodationIdsQueryHandler : TravelQueryHandler<PhotosOfAccommodationsByAccommodationIdsQuery, Photo, IEnumerable<AccommodationPhoto>>
    {
        public override async Task<IEnumerable<AccommodationPhoto>> HandleAsync(PhotosOfAccommodationsByAccommodationIdsQuery query, CancellationToken cancellationToken)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Source, query);

            return await projection.ToArrayAsync(cancellationToken);
        }

        private IQueryable<AccommodationPhoto> ProjectToQueryableOfAccommodationPhoto(IQueryable<Photo> source, PhotosOfAccommodationsByAccommodationIdsQuery query)
        {
            var photoOfAccommodations = from p in source
                                        where query.AccommodationIds.Contains(p.RealEstateId)
                                        select p;

            if (query.OnlyDefaultPhotos) photoOfAccommodations = photoOfAccommodations.Where(p => p.IsDefault);

            return ProjectTo<AccommodationPhoto>(photoOfAccommodations);
        }

        public PhotosOfAccommodationsByAccommodationIdsQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}