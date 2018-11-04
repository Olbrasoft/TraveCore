using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class PagedAccommodationItems : HandlerWithDependentSource<GetPagedAccommodationItems, LocalizedAccommodation, IResultWithTotalCount<AccommodationItem>>
    {
        public PagedAccommodationItems(IHaveGlobalizationQueryable<LocalizedAccommodation> ownerQueryable, IProjection projector) : base(ownerQueryable, projector)
        {
        }

        public override IResultWithTotalCount<AccommodationItem> Handle(GetPagedAccommodationItems query)
        {
            var localizedAccommodations = PreHandle(Source, query);

            var accommodationItems = ProjectTo<AccommodationItem>(localizedAccommodations);

            var result = new ResultWithTotalCount<AccommodationItem>
            {
                Result = accommodationItems.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArray(),

                TotalCount = accommodationItems.Count()
            };

            return result;
        }

        public override async Task<IResultWithTotalCount<AccommodationItem>> HandleAsync(GetPagedAccommodationItems query, CancellationToken cancellationToken)
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

        private static IQueryable<LocalizedAccommodation> PreHandle(IQueryable<LocalizedAccommodation> source, GetPagedAccommodationItems query)
        {
            var localizedAccommodationQueryable = source.Include(p => p.Accommodation).Where(p => p.LanguageId == query.LanguageId);

            var localizedAccommodationOrderedQueryable = query.Sorting(localizedAccommodationQueryable);

            return localizedAccommodationOrderedQueryable;
        }
    }
}