using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers
{
    public class PagedAccommodationItemsByLanguageIdQueryHandler : TravelQueryHandler<PagedAccommodationItemsByLanguageIdQuery, RealEstate,
        IResultWithTotalCount<AccommodationItem>>
    {
        public override async Task<IResultWithTotalCount<AccommodationItem>> HandleAsync(PagedAccommodationItemsByLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var localizedAccommodations = PreHandle(Source, query);
            var accommodationItems = ProjectTo<AccommodationItem>(localizedAccommodations);

            var result = new ResultWithTotalCount<AccommodationItem>
            {
                Result = await accommodationItems.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(cancellationToken),

                TotalCount = await accommodationItems.CountAsync(cancellationToken)
            };

            return result;
        }

        private static IQueryable<LocalizedRealEstate> PreHandle(IQueryable<RealEstate> source, PagedAccommodationItemsByLanguageIdQuery query)
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