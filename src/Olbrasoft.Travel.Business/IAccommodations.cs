using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Transfer.Object;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Business
{
    public interface IAccommodations
    {
        AccommodationDetail Get(int id, int languageId);

        Task<AccommodationDetail> GetAsync(int id, int languageId, CancellationToken cancellationToken = default(CancellationToken));

        IResultWithTotalCount<AccommodationItem> Get(
            IPageInfo pagingSettings, int languageId, Func<IQueryable<LocalizedAccommodation>, IOrderedQueryable<LocalizedAccommodation>> sorting
        );

        Task<IResultWithTotalCount<AccommodationItem>> GetAsync(
            IPageInfo pagingSettings,
            int languageId,
            Func<IQueryable<LocalizedAccommodation>, IOrderedQueryable<LocalizedAccommodation>> sorting,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        //Task<IPagedList<AccommodationItem>> GetAsync(
        //    IPageInfo pagingSettings,
        //    int languageId,
        //    Func<IQueryable<LocalizedAccommodation>, IOrderedQueryable<LocalizedAccommodation>> sorting
        //);
    }
}