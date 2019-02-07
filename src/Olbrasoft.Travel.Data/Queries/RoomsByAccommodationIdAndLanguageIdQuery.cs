using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class RoomsByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<IEnumerable<Room>>
    {
        public RoomsByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}