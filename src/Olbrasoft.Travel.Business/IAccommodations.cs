using Olbrasoft.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Business
{
    public interface IAccommodations
    {
        PropertyDetail Get(int id, int languageId);

        Task<PropertyDetail> GetAsync(int id, int languageId, CancellationToken cancellationToken = default(CancellationToken));

        IResultWithTotalCount<PropertyItem> Get(
            IPageInfo pagingSettings, int languageId, Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> sorting
        );

        Task<IResultWithTotalCount<PropertyItem>> GetAsync(
            IPageInfo pagingSettings,
            int languageId,
            Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> sorting,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string[] terms, int languageId,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}