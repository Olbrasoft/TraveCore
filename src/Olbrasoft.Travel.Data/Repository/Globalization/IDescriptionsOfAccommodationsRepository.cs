using Olbrasoft.Travel.Data.Entity.Globalization;
using SharpRepository.Repository;

namespace Olbrasoft.Travel.Data.Repository.Globalization
{
    public interface IDescriptionsOfAccommodationsRepository : IRepository<LocalizedDescriptionOfAccommodation>, ICompoundKeyRepository<LocalizedDescriptionOfAccommodation, int, int, int>
    {
    }
}