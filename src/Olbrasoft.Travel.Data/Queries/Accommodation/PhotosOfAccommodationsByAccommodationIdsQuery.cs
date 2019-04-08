using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PhotosOfAccommodationsByAccommodationIdsQuery : Query<IEnumerable<PropertyPhotoDto>>
    {
        public IEnumerable<int> AccommodationIds { get; set; }
        public bool OnlyDefaultPhotos { get; set; }

        public PhotosOfAccommodationsByAccommodationIdsQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}