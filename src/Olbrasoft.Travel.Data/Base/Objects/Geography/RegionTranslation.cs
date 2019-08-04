using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.Base.Objects.Geography
{
    public class RegionTranslation : Translation
    {
        [Required]
        [MaxLength(255)]
        public virtual string Name { get; set; }

        [MaxLength(510)]
        public string LongName { get; set; }

        public virtual Region Region { get; set; }
    }
}