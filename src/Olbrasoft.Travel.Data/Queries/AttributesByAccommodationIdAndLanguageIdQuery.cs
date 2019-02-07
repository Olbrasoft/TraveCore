using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class AttributesByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<IEnumerable<Attribute>>
    {
        public AttributesByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}