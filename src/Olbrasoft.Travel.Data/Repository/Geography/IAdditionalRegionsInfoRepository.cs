using System.Collections.Generic;
using Olbrasoft.Data.Repository.Bulk;
using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Repository.Geography
{
    public interface IAdditionalRegionsInfoRepository<T> : IBaseRepository<T>, IRepository<T>
        where T : OwnerCreatorIdAndCreator, IAdditionalRegionInfo
    {
        IReadOnlyDictionary<string, int> CodesToIds { get; }
    }
}