using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Base.Objects.Geography
{
    public class RegionSubtype : HaveName
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public ICollection<Region> Regions { get; set; }
    }
}