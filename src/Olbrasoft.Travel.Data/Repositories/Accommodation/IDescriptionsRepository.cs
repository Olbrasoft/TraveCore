using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using SharpRepository.Repository;

namespace Olbrasoft.Travel.Data.Repositories.Accommodation
{
    public interface IDescriptionsRepository : Olbrasoft.Data.Repository.Bulk.IRepository<DescriptionTranslation>, ICompoundKeyRepository<DescriptionTranslation, int, int, int>
    {
    }
}