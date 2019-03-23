using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public abstract class ByRealEstateIdQuery<TResult> : Query<TResult>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        protected ByRealEstateIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}