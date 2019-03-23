using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PhotosByRealEstateIdQuery :ByRealEstateIdQuery<IEnumerable<RealEstatePhoto>>
    {
        public PhotosByRealEstateIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}