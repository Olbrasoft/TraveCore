using Olbrasoft.Querying;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PagedPropertyItemsByRegionIdTranslationQuery : PagedPropertyItemsTranslationQuery
    {
        public PagedPropertyItemsByRegionIdTranslationQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }

        public int RegionId { get; set; }
    }
}