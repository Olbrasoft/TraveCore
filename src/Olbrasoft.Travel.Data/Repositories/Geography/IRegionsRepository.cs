using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Repositories.Geography
{
    public interface IRegionsRepository : Olbrasoft.Data.Repository.Bulk.IRepository<Region>, ITravelRepository<Region>
    {
        IReadOnlyDictionary<long, int> ExpediaIdsToIds { get; }
    }
}