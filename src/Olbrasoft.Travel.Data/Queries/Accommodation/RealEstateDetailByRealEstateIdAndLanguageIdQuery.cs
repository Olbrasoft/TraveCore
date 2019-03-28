using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class RealEstateDetailByRealEstateIdAndLanguageIdQuery : ByRealEstateIdAndLanguageIdQuery<PropertyDetail>
    {
        public RealEstateDetailByRealEstateIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}