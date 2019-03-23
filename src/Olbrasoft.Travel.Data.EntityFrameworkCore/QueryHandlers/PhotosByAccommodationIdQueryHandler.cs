using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class PhotosByAccommodationIdQueryHandler : TravelQueryHandler<PhotosByRealEstateIdQuery, Photo, IEnumerable<RealEstatePhoto>>
    {
        public override async Task<IEnumerable<RealEstatePhoto>> HandleAsync(PhotosByRealEstateIdQuery query,
            CancellationToken cancellationToken)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Source, query);

            return await projection.ToArrayAsync(cancellationToken);
        }

        private IQueryable<RealEstatePhoto> ProjectToQueryableOfAccommodationPhoto(
            IQueryable<Photo> source, PhotosByRealEstateIdQuery query)
        {
            var photosOfRooms = Source.SelectMany(p => p.ToTypesOfRooms).Select(p => p.Id);

            var photoOfAccommodations = source
                .Where(p => p.RealEstateId == query.AccommodationId)
                .Where(p => !photosOfRooms.Contains(p.Id))
                .OrderBy(p => p.IsDefault);

            return ProjectTo<RealEstatePhoto>(photoOfAccommodations);
        }

        public PhotosByAccommodationIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}