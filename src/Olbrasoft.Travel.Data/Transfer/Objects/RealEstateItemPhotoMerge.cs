using System.Collections.Generic;
using System.Linq;
using Olbrasoft.Pagination;

namespace Olbrasoft.Travel.Data.Transfer.Objects
{
    public class RealEstateItemPhotoMerge : IAccommodationItemPhotoMerge
    {
        public IResultWithTotalCount<RealEstateItem> Merge(IResultWithTotalCount<RealEstateItem> master, IEnumerable<RealEstatePhoto> slave)
        {
            foreach (var photo in slave)
            {
                master.Result.First(p => p.Id == photo.RealEstateId).Photo = $"https://i.travelapi.com/hotels/{photo.Path}/{photo.Name}_l.{photo.Extension}";
            }

            return master;
        }
    }
}