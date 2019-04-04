using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PhotosPropertyQuery :PropertyQuery<IEnumerable<PropertyPhotoDto>>
    {
        public PhotosPropertyQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}