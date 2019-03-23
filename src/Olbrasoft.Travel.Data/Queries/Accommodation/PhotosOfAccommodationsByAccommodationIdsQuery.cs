using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PhotosOfAccommodationsByAccommodationIdsQuery : Query<IEnumerable<RealEstatePhoto>>
    {
        public IEnumerable<int> AccommodationIds { get; set; }
        public bool OnlyDefaultPhotos { get; set; }

        public PhotosOfAccommodationsByAccommodationIdsQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}