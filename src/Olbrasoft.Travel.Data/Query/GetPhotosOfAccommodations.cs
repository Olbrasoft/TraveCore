using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Query
{
    public class GetPhotosOfAccommodations : QueryWithDependentProvider<IEnumerable<AccommodationPhoto>>
    {
        public IEnumerable<int> AccommodationIds { get; set; }
        public bool OnlyDefaultPhotos { get; set; }

        public GetPhotosOfAccommodations(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}