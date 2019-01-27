using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using Olbrasoft.Data.Queries;

namespace Olbrasoft.Travel.Data.Query
{
    public class RoomsByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<IEnumerable<Room>>
    {
        public RoomsByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}