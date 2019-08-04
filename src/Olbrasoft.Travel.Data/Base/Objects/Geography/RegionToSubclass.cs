using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Base.Objects.Geography
{
    [Table("RegionsToSubclasses", Schema = nameof(Geography))]
    public class RegionToSubclass : ManyToMany
    {
        public Region Region { get; set; }
        public Subclass Subclass { get; set; }
    }
}