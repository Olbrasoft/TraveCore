using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Query
{
    public class PhotosByAccommodationIdQuery :ByAccommodationIdQuery<IEnumerable<AccommodationPhoto>>
    {
        public PhotosByAccommodationIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}