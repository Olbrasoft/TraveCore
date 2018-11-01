using Olbrasoft.Data.Query;
using Olbrasoft.Globalization;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Query
{
    public class GetRooms : QueryWithDependentProvider<IEnumerable<Room>>, IHaveLanguageId<int>, IHaveAccommodationId
    {
        public int LanguageId { get; set; }
        public int AccommodationId { get; set; }

        public GetRooms(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}