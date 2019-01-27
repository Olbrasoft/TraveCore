using System.Collections.Generic;
using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Query
{
    public class RoomPhotosByAccommodationIdQuery : ByAccommodationIdQuery<IEnumerable<RoomPhoto>>
    {
        public RoomPhotosByAccommodationIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}