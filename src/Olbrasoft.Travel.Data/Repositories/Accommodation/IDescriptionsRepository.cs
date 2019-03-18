using Olbrasoft.Travel.Data.Accommodation;
using SharpRepository.Repository;

namespace Olbrasoft.Travel.Data.Repositories.Accommodation
{
    public interface IDescriptionsRepository : Olbrasoft.Data.Repository.Bulk.IRepository<LocalizedDescription>, ICompoundKeyRepository<LocalizedDescription, int, int, int>
    {
    }
}