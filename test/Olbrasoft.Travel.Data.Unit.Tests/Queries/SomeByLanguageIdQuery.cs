using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    internal class SomeByLanguageIdQuery : ByLanguageIdQuery<object>
    {
        public SomeByLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}