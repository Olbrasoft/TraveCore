using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class PropertyDetailByPropertyIdAndLanguageIdQuery : ByPropertyIdAndLanguageIdQuery<PropertyDetail>
    {
        public PropertyDetailByPropertyIdAndLanguageIdQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}