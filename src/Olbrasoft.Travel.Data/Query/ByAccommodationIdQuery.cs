using Olbrasoft.Data.Query;

namespace Olbrasoft.Travel.Data.Query
{
    public abstract class ByAccommodationIdQuery<TResult> : QueryWithDependentProvider<TResult>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        protected ByAccommodationIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}