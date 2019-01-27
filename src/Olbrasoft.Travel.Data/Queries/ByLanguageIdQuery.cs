using Olbrasoft.Data.Query;
using Olbrasoft.Globalization;

namespace Olbrasoft.Travel.Data.Queries
{
    public abstract class ByLanguageIdQuery<TResult> : QueryWithDependentProvider<TResult> ,IHaveLanguageId<int>
    {
        public int LanguageId { get; set; }

        protected ByLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }

    }
}