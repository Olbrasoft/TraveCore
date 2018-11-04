using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class PhotosByAccommodationId : AsyncHandlerWithDependentSource<GetPhotosByAccommodationId,
        PhotoOfAccommodation,
        IEnumerable<AccommodationPhoto>>
    {
        public PhotosByAccommodationId(IHavePropertyQueryable<PhotoOfAccommodation> ownerQueryable, IProjection projector) : base(ownerQueryable, projector)
        {
        }

        public override async Task<IEnumerable<AccommodationPhoto>> HandleAsync(GetPhotosByAccommodationId query,
            CancellationToken cancellationToken)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Source, query);

            return await projection.ToArrayAsync(cancellationToken);
        }

        private IQueryable<AccommodationPhoto> ProjectToQueryableOfAccommodationPhoto(
            IQueryable<PhotoOfAccommodation> source, GetPhotosByAccommodationId query)
        {
            var photosOfRooms = Source.SelectMany(p => p.ToTypesOfRooms).Select(p => p.Id);

            var photoOfAccommodations = source
                .Include(p => p.PathToPhoto)
                .Include(p => p.FileExtension)
                .Where(p => p.AccommodationId == query.AccommodationId)
                .Where(p => !photosOfRooms.Contains(p.Id))
                .OrderBy(p => p.IsDefault);

            return ProjectTo<AccommodationPhoto>(photoOfAccommodations);
        }
    }
}