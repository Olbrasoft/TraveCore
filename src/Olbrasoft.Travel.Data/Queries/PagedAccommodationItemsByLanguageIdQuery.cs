using System;
using System.Linq;
using Olbrasoft.Data.Query;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class PagedAccommodationItemsByLanguageIdQuery : ByLanguageIdQuery<IResultWithTotalCount<AccommodationItem>>
    {
        public Func<IQueryable<LocalizedAccommodation>, IOrderedQueryable<LocalizedAccommodation>> Sorting
        {
            get; set;
        }

        public IPageInfo Paging { get; set; }

        public PagedAccommodationItemsByLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}