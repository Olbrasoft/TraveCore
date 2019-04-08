using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    internal class AwesomeByPropertyIdAndLanguageIdQuery : ByPropertyIdAndLanguageIdQuery<object>
    {
        public AwesomeByPropertyIdAndLanguageIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}