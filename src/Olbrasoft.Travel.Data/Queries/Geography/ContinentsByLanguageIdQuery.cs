using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Geography
{
    public class ContinentsByLanguageIdQuery : ByLanguageIdQuery<IEnumerable<ContinentItem>>
    {
        public ContinentsByLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}