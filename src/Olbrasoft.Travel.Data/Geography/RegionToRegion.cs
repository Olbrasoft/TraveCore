using Olbrasoft.Travel.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Geography
{
    [Table("RegionsToRegions", Schema = nameof(Geography))]
    public class RegionToRegion : ManyToMany
    {
        public virtual Region Region { get; set; }

        public virtual Region ParentRegion { get; set; }
    }
}