using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using Olbrasoft.Data.Queries;

namespace Olbrasoft.Travel.Data.Query
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