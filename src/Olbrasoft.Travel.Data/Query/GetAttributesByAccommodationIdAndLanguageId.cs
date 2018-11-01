using System.Collections.Generic;
using Olbrasoft.Data.Query;
using Olbrasoft.Globalization;

namespace Olbrasoft.Travel.Data.Query
{
    public class GetAttributesByAccommodationIdAndLanguageId : QueryWithDependentProvider<IEnumerable<Transfer.Object.Attribute>>, IHaveAccommodationId, IHaveLanguageId<int>
    {
        public int AccommodationId { get; set; }
        public int LanguageId { get; set; }

        public GetAttributesByAccommodationIdAndLanguageId(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}