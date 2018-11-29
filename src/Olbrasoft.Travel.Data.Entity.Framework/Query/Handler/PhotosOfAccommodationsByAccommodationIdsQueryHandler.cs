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
    public class PhotosOfAccommodationsByAccommodationIdsQueryHandler : TravelQueryHandler<IPropertyContext, PhotosOfAccommodationsByAccommodationIdsQuery,IQueryable<PhotoOfAccommodation>,IEnumerable<AccommodationPhoto>>
    {
        public PhotosOfAccommodationsByAccommodationIdsQueryHandler(IPropertyContext context, IProjection projector) : base(context, projector)
        {
        }

        protected override IQueryable<PhotoOfAccommodation> GetSource()
        {
            return Context.PhotosOfAccommodations;
        }

        public override async Task<IEnumerable<AccommodationPhoto>> HandleAsync(PhotosOfAccommodationsByAccommodationIdsQuery query, CancellationToken cancellationToken)
        {
            var projection = ProjectToQueryableOfAccommodationPhoto(Source, query);

            return await projection.ToArrayAsync(cancellationToken);
        }

        private IQueryable<AccommodationPhoto> ProjectToQueryableOfAccommodationPhoto(IQueryable<PhotoOfAccommodation> source, PhotosOfAccommodationsByAccommodationIdsQuery query)
        {
           var photoOfAccommodations = from p in source
                where query.AccommodationIds.Contains(p.AccommodationId)
                select p;

            if (query.OnlyDefaultPhotos) photoOfAccommodations = photoOfAccommodations.Where(p => p.IsDefault);

            return ProjectTo<AccommodationPhoto>(photoOfAccommodations);
        }
    }
}