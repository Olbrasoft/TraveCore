using System.Collections.Generic;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Query
{
    public class GetRoomPhotosByAccommodationId : QueryWithDependentProvider<IEnumerable<RoomPhoto>>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        public GetRoomPhotosByAccommodationId(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}