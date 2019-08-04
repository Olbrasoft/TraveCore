using Olbrasoft.Querying;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public abstract class PropertyQuery<TResult> : Query<TResult>, IHaveAccommodationId
    {
        public int PropertyId { get; set; }

        protected PropertyQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}