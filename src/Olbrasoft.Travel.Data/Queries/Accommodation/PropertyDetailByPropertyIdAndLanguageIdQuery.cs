using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PropertyDetailByPropertyIdAndLanguageIdQuery : ByPropertyIdAndLanguageIdQuery<PropertyDetail>
    {
        public PropertyDetailByPropertyIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}