using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class ContinentsByLanguageIdQuery : ByLanguageIdQuery<IEnumerable<ContinentItem>>
    {
        public ContinentsByLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}