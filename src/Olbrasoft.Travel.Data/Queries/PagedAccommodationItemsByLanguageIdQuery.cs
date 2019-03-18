using System;
using System.Linq;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class PagedAccommodationItemsByLanguageIdQuery : ByLanguageIdQuery<IResultWithTotalCount<AccommodationItem>>
    {
        public Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> Sorting
        {
            get; set;
        }

        public IPageInfo Paging { get; set; }

        public PagedAccommodationItemsByLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}