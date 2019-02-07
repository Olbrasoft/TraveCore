using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class RoomPhotosByAccommodationIdQuery : ByAccommodationIdQuery<IEnumerable<RoomPhoto>>
    {
        public RoomPhotosByAccommodationIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}