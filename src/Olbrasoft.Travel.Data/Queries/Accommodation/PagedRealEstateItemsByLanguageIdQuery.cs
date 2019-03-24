﻿using System;
using System.Linq;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PagedRealEstateItemsByLanguageIdQuery : ByLanguageIdQuery<IResultWithTotalCount<RealEstateItem>>
    {
        public Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> Sorting
        {
            get; set;
        }

        public IPageInfo Paging { get; set; }

        public PagedRealEstateItemsByLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}