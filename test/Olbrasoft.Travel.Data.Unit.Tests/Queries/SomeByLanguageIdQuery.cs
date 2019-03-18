using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class SomeByLanguageIdQuery : ByLanguageIdQuery<object>
    {
        public SomeByLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}