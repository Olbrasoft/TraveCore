using System.Collections.Generic;
using Olbrasoft.Data.Query;

namespace Olbrasoft.Travel.Data.Query
{
    public class AttributesByAccommodationIdAndLanguageIdQuery : ByLanguageIdQuery<IEnumerable<Transfer.Object.Attribute>>, IHaveAccommodationId
    {
        public int AccommodationId { get; set; }

        public AttributesByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}