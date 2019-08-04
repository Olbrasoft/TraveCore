using Olbrasoft.Paging;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System;
using System.Linq;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PagedPropertyItemsTranslationQuery : TranslationQuery<IResultWithTotalCount<PropertyItem>>
    {
        public Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> Sorting
        {
            get; set;
        }

        public IPageInfo Paging { get; set; }

        public PagedPropertyItemsTranslationQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}