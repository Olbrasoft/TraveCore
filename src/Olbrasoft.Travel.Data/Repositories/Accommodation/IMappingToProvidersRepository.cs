using System.Collections.Generic;
using Olbrasoft.Data.Repository.Bulk;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Repositories.Accommodation
{
    public interface IMappingToProvidersRepository<T> : IRepository<T>, ITravelRepository<T> where T : class, IHaveExpediaId<int>
    {
        HashSet<int> ExpediaIds { get; }
        IReadOnlyDictionary<int, int> ExpediaIdsToIds { get; }
    }
}