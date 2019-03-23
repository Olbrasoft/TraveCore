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
        RealEstateDetail Get(int id, int languageId);

        Task<RealEstateDetail> GetAsync(int id, int languageId, CancellationToken cancellationToken = default(CancellationToken));

        IResultWithTotalCount<RealEstateItem> Get(
            IPageInfo pagingSettings, int languageId, Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> sorting
        );

        Task<IResultWithTotalCount<RealEstateItem>> GetAsync(
            IPageInfo pagingSettings,
            int languageId,
            Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> sorting,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<IEnumerable<Suggestion>> SuggestionsAsync(string[] terms, int languageId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}