using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class AttributesByPropertyIdAndLanguageIdQuery : ByPropertyIdAndLanguageIdQuery<IEnumerable<AttributeDto>>
    {
        public AttributesByPropertyIdAndLanguageIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}