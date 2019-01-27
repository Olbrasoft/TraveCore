using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Query.Handler
{
    public class PagedAccommodationItemsByLanguageIdQueryHandler : TravelQueryHandler<IPropertyContext,PagedAccommodationItemsByLanguageIdQuery, IQueryable<Property.Accommodation>,
        IResultWithTotalCount<AccommodationItem>>
    {
        public PagedAccommodationItemsByLanguageIdQueryHandler(IPropertyContext context, IProjection projector) : base(context, projector)
        {
        }

        protected override IQueryable<Property.Accommodation> GetSource()
        {
            return Context.Accommodations;
        }

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

        private static IQueryable<LocalizedAccommodation> PreHandle(IQueryable<Property.Accommodation> source, PagedAccommodationItemsByLanguageIdQuery query)
        {
            var localizedAccommodations = source.SelectMany(p => p.LocalizedAccommodations);

            var localizedAccommodationQueryable = localizedAccommodations.Include(p => p.Accommodation).Where(p => p.LanguageId == query.LanguageId);

            var localizedAccommodationOrderedQueryable = query.Sorting(localizedAccommodationQueryable);

            return localizedAccommodationOrderedQueryable;
        }
    }
}