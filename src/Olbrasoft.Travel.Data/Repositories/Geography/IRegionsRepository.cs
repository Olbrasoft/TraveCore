using System.Collections.Generic;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.Repositories.Geography
{
    public interface IRegionsRepository : Olbrasoft.Data.Repository.Bulk.IRepository<Region>, ITravelRepository<Region>
    {
        IReadOnlyDictionary<long, int> ExpediaIdsToIds { get; }
    }
}