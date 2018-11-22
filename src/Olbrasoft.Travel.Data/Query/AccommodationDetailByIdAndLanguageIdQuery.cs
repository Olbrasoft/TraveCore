using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Query
{
    public class AccommodationDetailByIdAndLanguageIdQuery : ByLanguageIdQuery<AccommodationDetail>
    {
        public int Id { get; set; }

        public AccommodationDetailByIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}