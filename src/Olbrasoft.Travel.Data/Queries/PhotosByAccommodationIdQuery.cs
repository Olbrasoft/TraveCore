using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class PhotosByAccommodationIdQuery :ByAccommodationIdQuery<IEnumerable<AccommodationPhoto>>
    {
        public PhotosByAccommodationIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}