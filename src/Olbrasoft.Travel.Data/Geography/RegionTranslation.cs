using Olbrasoft.Travel.Data.Localization;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Geography
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