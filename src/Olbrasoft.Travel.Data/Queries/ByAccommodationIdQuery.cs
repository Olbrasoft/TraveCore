using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Queries
{
    public abstract class ByAccommodationIdQuery<TResult> : QueryWithDependentProvider<TResult>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        protected ByAccommodationIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}