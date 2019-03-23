using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class AttributesByRealEstateIdAndLanguageIdQuery : ByRealEstateIdAndLanguageIdQuery<IEnumerable<Attribute>>
    {
        public AttributesByRealEstateIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}