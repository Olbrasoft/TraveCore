using System.Collections.Generic;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Query
{
    public class GetPhotosByAccommodationId : QueryWithDependentProvider<IEnumerable<AccommodationPhoto>>
    {
        public int AccommodationId { get; set; }
        
        public GetPhotosByAccommodationId(IProvider queryProvider) : base(queryProvider)
        {

        }
    }
}