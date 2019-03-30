using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public abstract class ByPropertyIdQuery<TResult> : Query<TResult>, IHaveAccommodationId
    {
        public int PropertyId { get; set; }

        protected ByPropertyIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}