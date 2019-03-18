using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Queries
{
    public abstract class ByAccommodationIdAndLanguageIdQuery<TResult> : ByLanguageIdQuery<TResult>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        protected ByAccommodationIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}