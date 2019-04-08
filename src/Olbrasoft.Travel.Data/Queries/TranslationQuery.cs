using Olbrasoft.Data.Querying;
using Olbrasoft.Globalization;

namespace Olbrasoft.Travel.Data.Queries
{
    public abstract class TranslationQuery<TResult> : Query<TResult>, IHaveLanguageId<int>
    {
        public int LanguageId { get; set; }

        protected TranslationQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}