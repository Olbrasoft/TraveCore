using System.Collections.Generic;
using Olbrasoft.Data.Repository.Bulk;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Repositories.Geography
{
    public interface IAdditionalRegionsInfoRepository<T> : ITravelRepository<T>, IRepository<T>
        where T : OwnerCreatorInfoAndCreator, IAdditionalRegionInfo
    {
        IReadOnlyDictionary<string, int> CodesToIds { get; }
    }
}