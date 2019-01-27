using Olbrasoft.Data.Queries;
using Olbrasoft.Globalization;

namespace Olbrasoft.Travel.Data.Query
{
    public abstract class ByLanguageIdQuery<TResult> : QueryWithDependentProvider<TResult> ,IHaveLanguageId<int>
    {
        public int LanguageId { get; set; }

        protected ByLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }

    }
}