using System.Collections.Generic;
using Olbrasoft.Travel.Data.Base;
using SharpRepository.Repository;

namespace Olbrasoft.Travel.Data.Repositories
{
    public interface INamesRepository<T> : Olbrasoft.Data.Repository.Bulk.IRepository<T>, IRepository<T> where T : class, IHaveName
    {
        int GetId(string name);
        IEnumerable<string> Names { get; }
        IReadOnlyDictionary<string, int> NamesToIds { get; }
    }
}