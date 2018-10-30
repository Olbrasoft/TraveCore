using System;
using System.Collections.Generic;
using Olbrasoft.Data.Repository.Bulk;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Repository
{
    public interface IPhotosOfAccommodationsRepository : IRepository<PhotoOfAccommodation>,
        IBaseRepository<PhotoOfAccommodation>
    {
        IReadOnlyDictionary<Tuple<int, string, int>, int> GetPathIdsAndFileIdsAndExtensionIdsToIds();

        //IReadOnlyDictionary<Tuple<int, string, int>, int> GetPathIdsAndFileIdsAndExtensionIdsToIds(
        //    IEnumerable<int> pathIds);
    }
}