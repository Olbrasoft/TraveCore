using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Transfer.Object;
using System;
using System.Linq;
using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Query
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