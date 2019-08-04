using Microsoft.EntityFrameworkCore;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Mapping;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PagedPropertyItemsByRegionIdTranslationQueryHandler : TravelQueryHandler<PagedPropertyItemsByRegionIdTranslationQuery, IResultWithTotalCount<PropertyItem>,PropertyToRegion>
    {
       

        public override async Task<IResultWithTotalCount<PropertyItem>> HandleAsync(PagedPropertyItemsByRegionIdTranslationQuery query, CancellationToken token)
        {
            var localizedAccommodations = PreHandle(Entities(), query);
            var accommodationItems = ProjectTo<PropertyItem>(localizedAccommodations);

            var result = new ResultWithTotalCount<PropertyItem>
            {
                Result = await accommodationItems.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(token),

                TotalCount = await accommodationItems.CountAsync(token)
            };

            return result;
        }

        private static IQueryable<PropertyTranslation> PreHandle(IQueryable<PropertyToRegion> source, PagedPropertyItemsByRegionIdTranslationQuery query)
        {
            var properties = source.Where(p => p.ToId == query.RegionId).Select(p => p.Property);

            var localizedAccommodations = properties.SelectMany(p => p.PropertiesTranslations);

            var localizedAccommodationQueryable = localizedAccommodations.Include(p => p.Property).Where(p => p.LanguageId == query.LanguageId);

            var localizedAccommodationOrderedQueryable = query.Sorting(localizedAccommodationQueryable);

            return localizedAccommodationOrderedQueryable;
        }

        public PagedPropertyItemsByRegionIdTranslationQueryHandler(IProjection projector, TravelDbContext context) : base(projector, context)
        {
        }
    }
}