using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class RoomPhotosByRealEstateIdQuery : ByRealEstateIdQuery<IEnumerable<RoomPhoto>>
    {
        public RoomPhotosByRealEstateIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}