using System.Collections.Generic;
using System.Linq;
using Olbrasoft.Pagination;

namespace Olbrasoft.Travel.Data.Transfer.Objects
{
    public class AccommodationItemPhotoMerge : IAccommodationItemPhotoMerge
    {
        public IResultWithTotalCount<AccommodationItem> Merge(IResultWithTotalCount<AccommodationItem> master, IEnumerable<AccommodationPhoto> slave)
        {
            foreach (var photo in slave)
            {
                master.Result.First(p => p.Id == photo.AccommodationId).Photo = $"https://i.travelapi.com/hotels/{photo.Path}/{photo.Name}_l.{photo.Extension}";
            }

            return master;
        }
    }
}