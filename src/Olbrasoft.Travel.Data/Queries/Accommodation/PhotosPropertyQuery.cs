using System.Collections.Generic;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PhotosPropertyQuery :PropertyQuery<IEnumerable<PropertyPhotoDto>>
    {
        public PhotosPropertyQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}