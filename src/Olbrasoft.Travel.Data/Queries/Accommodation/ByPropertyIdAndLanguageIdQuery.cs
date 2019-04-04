using Olbrasoft.Data.Querying;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public abstract class ByPropertyIdAndLanguageIdQuery<TResult> : TranslationQuery<TResult>, IHaveAccommodationId
    {
        public int PropertyId { get; set; }

        protected ByPropertyIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}