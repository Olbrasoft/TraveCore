using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Repository.Geography;
using System.Collections.Generic;
using System.Linq;

namespace Olbrasoft.Travel.Data.Entity.Framework.Repository.Geography
{
    public class TypesOfRegionsRepository : NamesRepository<TypeOfRegion>, ITypesOfRegionsRepository
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

        public TypesOfRegionsRepository(GeographyDatabaseContext context) : base(context)
        {
        }

        public override void ClearCache()
        {
            DescriptionsToIds = null;
            base.ClearCache();
        }
    }
}