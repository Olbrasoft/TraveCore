using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Geography
{
    [Table("RegionsToSubclasses", Schema = nameof(Geography))]
    public class RegionToSubclass : ManyToMany
    {
        public Region Region { get; set; }
        public Subclass Subclass { get; set; }
    }
}