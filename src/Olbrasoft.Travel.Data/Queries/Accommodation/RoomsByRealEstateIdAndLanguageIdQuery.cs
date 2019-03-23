using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class RoomsByRealEstateIdAndLanguageIdQuery : ByRealEstateIdAndLanguageIdQuery<IEnumerable<Room>>
    {
        public RoomsByRealEstateIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}