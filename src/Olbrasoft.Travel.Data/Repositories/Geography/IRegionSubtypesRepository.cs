using System.Collections.Generic;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.Repositories.Geography
{
    public interface IRegionSubtypesRepository : INamesRepository<RegionSubtype>
    {
        IReadOnlyDictionary<string, int> DescriptionsToIds { get; }
    }
}