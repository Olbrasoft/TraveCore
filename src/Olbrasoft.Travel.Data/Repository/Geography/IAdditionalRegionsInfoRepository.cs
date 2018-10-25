using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Repository.Geography
{
    public interface IAdditionalRegionsInfoRepository<T> : IBaseRepository<T>
        where T : OwnerCreatorIdAndCreator, IAdditionalRegionInfo
    {
        IReadOnlyDictionary<string, int> CodesToIds { get; }
    }
}