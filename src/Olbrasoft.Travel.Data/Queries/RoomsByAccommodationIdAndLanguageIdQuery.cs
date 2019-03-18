using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class RoomsByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<IEnumerable<Room>>
    {
        public RoomsByAccommodationIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}