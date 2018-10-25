using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Repository.Geography
{
    public interface IRegionsRepository : Olbrasoft.Data.Repository.Bulk.IRepository<Region>, IBaseRepository<Region>
    {
        IReadOnlyDictionary<long, int> EanIdsToIds { get; }
    }
}