using Olbrasoft.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Business
{
    public interface IAccommodations
    {
        AccommodationDetail Get(int id, int languageId);

        Task<AccommodationDetail> GetAsync(int id, int languageId, CancellationToken cancellationToken = default(CancellationToken));

        IResultWithTotalCount<AccommodationItem> Get(
            IPageInfo pagingSettings, int languageId, Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> sorting
        );

        Task<IResultWithTotalCount<AccommodationItem>> GetAsync(
            IPageInfo pagingSettings,
            int languageId,
            Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> sorting,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<IEnumerable<Suggestion>> SuggestionsAsync(string[] terms, int languageId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}