using System;
using System.Linq;

namespace Olbrasoft.Data.Query
{
    public interface IQueryWithSorting<T, TResult> : IQuery<TResult>
    {
        /// <summary>
        /// Gets a sort criteria applied on this query.
        /// </summary>
        Func<IQueryable<T>, IOrderedQueryable<T>> Sorting { get; set; }
    }
}