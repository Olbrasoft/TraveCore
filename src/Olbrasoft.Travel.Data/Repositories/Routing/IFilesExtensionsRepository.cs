using System.Collections.Generic;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.Repositories.Routing
{
    public interface IFilesExtensionsRepository : ITravelRepository<FileExtension>
    {
        HashSet<string> Extensions { get; }
        IReadOnlyDictionary<string, int> ExtensionsToIds { get; }

        void Save(IEnumerable<FileExtension> filesExtensions);
    }
}