using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity;
using SharpRepository.Repository;

namespace Olbrasoft.Travel.Data.Repository
{
    public interface IOfName<T> : Olbrasoft.Data.Repository.Bulk.IRepository<T>, IRepository<T> where T : class, IHaveName
    {
        int GetId(string name);
        IEnumerable<string> Names { get; }
        IReadOnlyDictionary<string, int> NamesToIds { get; }
    }
}