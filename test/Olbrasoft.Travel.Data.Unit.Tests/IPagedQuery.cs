using Olbrasoft.Data.Query;
using Olbrasoft.Pagination;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    public interface IPagedQuery<T, TResult> : IQueryWithSorting<T, TResult> 
    {
        IPageInfo Paging { get; set; }
    }
}