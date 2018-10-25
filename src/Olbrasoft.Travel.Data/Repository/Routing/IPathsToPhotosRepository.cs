using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Routing;

namespace Olbrasoft.Travel.Data.Repository.Routing
{
    public interface IPathsToPhotosRepository : IBaseRepository<PathToPhoto>
    {
        IReadOnlyDictionary<string, int> PathsToIds { get; }
        HashSet<string> Paths { get; }
    }
}