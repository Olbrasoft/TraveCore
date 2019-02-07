using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class PhotosByAccommodationIdQuery :ByAccommodationIdQuery<IEnumerable<AccommodationPhoto>>
    {
        public PhotosByAccommodationIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}