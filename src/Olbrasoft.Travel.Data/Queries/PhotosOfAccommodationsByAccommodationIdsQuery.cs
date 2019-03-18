using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class PhotosOfAccommodationsByAccommodationIdsQuery : Query<IEnumerable<AccommodationPhoto>>
    {
        public IEnumerable<int> AccommodationIds { get; set; }
        public bool OnlyDefaultPhotos { get; set; }

        public PhotosOfAccommodationsByAccommodationIdsQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}