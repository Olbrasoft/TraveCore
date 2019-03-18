using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Queries
{
    public abstract class ByAccommodationIdQuery<TResult> : Query<TResult>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        protected ByAccommodationIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}