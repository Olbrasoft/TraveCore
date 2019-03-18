using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class AttributesByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<IEnumerable<Attribute>>
    {
        public AttributesByAccommodationIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}