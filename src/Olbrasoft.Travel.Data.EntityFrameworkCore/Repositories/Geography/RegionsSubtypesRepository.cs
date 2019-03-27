using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories.Geography;
using System.Collections.Generic;
using System.Linq;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Geography
{
    public class RegionsSubtypesRepository : NamesRepository<RegionSubtype>, IRegionSubtypesRepository
    {
        private IReadOnlyDictionary<string, int> _descriptionsToIds;

        public IReadOnlyDictionary<string, int> DescriptionsToIds
        {
            get
            {
                return _descriptionsToIds ??
                       (_descriptionsToIds = GetAll(p => new { p.Description, p.Id }).ToDictionary(k => k.Description, v => v.Id));
            }

            private set => _descriptionsToIds = value;
        }

        public RegionsSubtypesRepository(DbContext context) : base(context)
        {
        }

        public override void ClearCache()
        {
            DescriptionsToIds = null;
            base.ClearCache();
        }
    }
}