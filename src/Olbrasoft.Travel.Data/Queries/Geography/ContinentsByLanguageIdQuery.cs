using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.Queries.Geography
{
    public class ContinentsByLanguageIdQuery : TranslationQuery<IEnumerable<ContinentItem>>
    {
        public ContinentsByLanguageIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}