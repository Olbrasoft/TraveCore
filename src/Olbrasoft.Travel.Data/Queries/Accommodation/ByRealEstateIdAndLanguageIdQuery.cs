using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public abstract class ByRealEstateIdAndLanguageIdQuery<TResult> : ByLanguageIdQuery<TResult>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        protected ByRealEstateIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}