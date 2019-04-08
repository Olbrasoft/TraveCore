using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class AwesomeByLanguageIdQuery : TranslationQuery<object>
    {
        public AwesomeByLanguageIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}