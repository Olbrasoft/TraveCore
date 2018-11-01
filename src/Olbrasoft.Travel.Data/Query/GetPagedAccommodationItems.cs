using Olbrasoft.Data.Query;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Transfer.Object;
using System;
using System.Linq;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Query
{
    public class GetPagedAccommodationItems : QueryWithDependentProvider<IResultWithTotalCount<AccommodationItem>>
    {
        public int LanguageId { get; set; }

        public Func<IQueryable<LocalizedAccommodation>, IOrderedQueryable<LocalizedAccommodation>> Sorting
        {
            get; set;
        }

        public IPageInfo Paging { get; set; }

        public GetPagedAccommodationItems(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}