using System;
using System.Collections.Generic;
using Olbrasoft.Data.Repository.Bulk;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Repositories.Accommodation
{
    public interface IPhotosRepository : IRepository<Photo>,
        ITravelRepository<Photo>
    {
        IReadOnlyDictionary<Tuple<int, string, int>, int> GetPathIdsAndFileIdsAndExtensionIdsToIds();

        //IReadOnlyDictionary<Tuple<int, string, int>, int> GetPathIdsAndFileIdsAndExtensionIdsToIds(
        //    IEnumerable<int> pathIds);
    }
}