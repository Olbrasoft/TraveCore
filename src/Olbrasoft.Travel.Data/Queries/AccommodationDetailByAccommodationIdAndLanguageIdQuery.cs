using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries
{
    public class AccommodationDetailByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<AccommodationDetail>
    {
        public AccommodationDetailByAccommodationIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}