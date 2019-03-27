using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PagedAccommodationItemsByLanguageIdQueryHandler : TravelQueryHandler<PagedRealEstateItemsByLanguageIdQuery, RealEstate,
        IResultWithTotalCount<RealEstateItem>>
    {
        public override async Task<IResultWithTotalCount<RealEstateItem>> HandleAsync(PagedRealEstateItemsByLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var localizedAccommodations = PreHandle(Source, query);
            var accommodationItems = ProjectTo<RealEstateItem>(localizedAccommodations);

            var result = new ResultWithTotalCount<RealEstateItem>
            {
                Result = await accommodationItems.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(cancellationToken),

                TotalCount = await accommodationItems.CountAsync(cancellationToken)
            };

            return result;
        }

        private static IQueryable<LocalizedRealEstate> PreHandle(IQueryable<RealEstate> source, PagedRealEstateItemsByLanguageIdQuery query)
        {
            var localizedAccommodations = source.SelectMany(p => p.LocalizedAccommodations);

            var localizedAccommodationQueryable = localizedAccommodations.Include(p => p.RealEstate).Where(p => p.LanguageId == query.LanguageId);

            var localizedAccommodationOrderedQueryable = query.Sorting(localizedAccommodationQueryable);

            return localizedAccommodationOrderedQueryable;
        }

        public PagedAccommodationItemsByLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}