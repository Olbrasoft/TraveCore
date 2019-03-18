using Olbrasoft.Data.Querying;
using Olbrasoft.Globalization;

namespace Olbrasoft.Travel.Data.Queries
{
    public abstract class ByLanguageIdQuery<TResult> : Query<TResult> ,IHaveLanguageId<int>
    {
        public int LanguageId { get; set; }

        protected ByLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }

    }
}