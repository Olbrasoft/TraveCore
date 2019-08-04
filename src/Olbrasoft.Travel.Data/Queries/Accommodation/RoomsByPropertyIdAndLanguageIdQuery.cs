using System.Collections.Generic;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class RoomsByPropertyIdAndLanguageIdQuery : ByPropertyIdAndLanguageIdQuery<IEnumerable<RoomDto>>
    {
        public RoomsByPropertyIdAndLanguageIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}