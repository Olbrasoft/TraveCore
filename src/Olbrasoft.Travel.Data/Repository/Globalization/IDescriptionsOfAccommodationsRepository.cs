using Olbrasoft.Travel.Data.Entity.Globalization;
using SharpRepository.Repository;

namespace Olbrasoft.Travel.Data.Repository.Globalization
{
    public interface IDescriptionsOfAccommodationsRepository : Olbrasoft.Data.Repository.Bulk.IRepository<LocalizedDescriptionOfAccommodation>, ICompoundKeyRepository<LocalizedDescriptionOfAccommodation, int, int, int>
    {
    }
}