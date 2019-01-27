using Olbrasoft.Data.Queries;

namespace Olbrasoft.Travel.Data.Queries
{
    public abstract class ByAccommodationIdAndLanguageIdQuery<TResult> : ByLanguageIdQuery<TResult>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        protected ByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}