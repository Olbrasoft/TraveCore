using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class PhotosOfAccommodationsByAccommodationIdsQuery : QueryWithDependentProvider<IEnumerable<AccommodationPhoto>>
    {
        public IEnumerable<int> AccommodationIds { get; set; }
        public bool OnlyDefaultPhotos { get; set; }

        public PhotosOfAccommodationsByAccommodationIdsQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}