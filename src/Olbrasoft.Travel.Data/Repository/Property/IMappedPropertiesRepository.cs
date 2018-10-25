using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Repository.Property
{
    public interface IMappedPropertiesRepository<T> : IBaseRepository<T> where T : class, IHaveEanId<int>
    {
        HashSet<int> EanIds { get; }
        IReadOnlyDictionary<int, int> EanIdsToIds { get; }
    }
}