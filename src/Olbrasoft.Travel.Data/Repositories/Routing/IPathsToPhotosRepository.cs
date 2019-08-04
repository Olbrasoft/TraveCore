using System.Collections.Generic;
using Olbrasoft.Data.Repository.Bulk;
using Olbrasoft.Travel.Data.Base.Objects.IO;

namespace Olbrasoft.Travel.Data.Repositories.Routing
{
    public interface IPathsToPhotosRepository : IRepository<PathToPhoto>, ITravelRepository<PathToPhoto>
    {
        IReadOnlyDictionary<string, int> PathsToIds { get; }
        HashSet<string> Paths { get; }
    }
}