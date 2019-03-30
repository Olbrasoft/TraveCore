using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class PagedAccommodationItemsByLanguageIdQueryHandler : TravelQueryHandler<PagedPropertyItemsByLanguageIdQuery, Property,
        IResultWithTotalCount<PropertyItem>>
    {
        public override async Task<IResultWithTotalCount<PropertyItem>> HandleAsync(PagedPropertyItemsByLanguageIdQuery query, CancellationToken cancellationToken)
        {
            var localizedAccommodations = PreHandle(Source, query);
            var accommodationItems = ProjectTo<PropertyItem>(localizedAccommodations);

            var result = new ResultWithTotalCount<PropertyItem>
            {
                Result = await accommodationItems.Skip(query.Paging.CalculateSkip()).Take(query.Paging.PageSize).ToArrayAsync(cancellationToken),

                TotalCount = await accommodationItems.CountAsync(cancellationToken)
            };

            return result;
        }

        private static IQueryable<PropertyTranslation> PreHandle(IQueryable<Property> source, PagedPropertyItemsByLanguageIdQuery query)
        {
            var localizedAccommodations = source.SelectMany(p => p.PropertiesTranslations);

            var localizedAccommodationQueryable = localizedAccommodations.Include(p => p.Property).Where(p => p.LanguageId == query.LanguageId);

            var localizedAccommodationOrderedQueryable = query.Sorting(localizedAccommodationQueryable);

            return localizedAccommodationOrderedQueryable;
        }

        public PagedAccommodationItemsByLanguageIdQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}