using Olbrasoft.Data.Query;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Query
{
    public class AttributesByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<IEnumerable<Transfer.Object.Attribute>>
    {
        public AttributesByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}