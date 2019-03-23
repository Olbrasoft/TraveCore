using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class RealEstateDetailByRealEstateIdAndLanguageIdQuery : ByRealEstateIdAndLanguageIdQuery<RealEstateDetail>
    {
        public RealEstateDetailByRealEstateIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}