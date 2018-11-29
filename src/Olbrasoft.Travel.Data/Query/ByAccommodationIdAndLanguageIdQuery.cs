using Olbrasoft.Data.Query;

namespace Olbrasoft.Travel.Data.Query
{
    public abstract class ByAccommodationIdAndLanguageIdQuery<TResult> : ByLanguageIdQuery<TResult>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        protected ByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}