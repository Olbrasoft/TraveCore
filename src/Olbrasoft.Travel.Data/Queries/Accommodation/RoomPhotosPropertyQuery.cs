using System.Collections.Generic;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class RoomPhotosPropertyQuery : PropertyQuery<IEnumerable<RoomPhotoDto>>
    {
        public RoomPhotosPropertyQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
        
    }
}