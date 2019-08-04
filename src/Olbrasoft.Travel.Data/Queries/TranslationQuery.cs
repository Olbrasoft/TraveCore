using Olbrasoft.Globalization;
using Olbrasoft.Querying;

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