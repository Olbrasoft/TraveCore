using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Repository.Geography
{
    public interface ITypesOfRegionsRepository : INamesRepository<TypeOfRegion>
    {
        IReadOnlyDictionary<string, int> DescriptionsToIds { get; }
    }
}