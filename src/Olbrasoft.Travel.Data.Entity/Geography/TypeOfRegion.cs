using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Entity.Geography
{
    public class TypeOfRegion : BaseName
    {
        public string Description { get; set; }
        public ICollection<RegionToType> RegionsToTypes { get; set; }
    }
}