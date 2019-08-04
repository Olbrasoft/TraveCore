using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class CaptionTranslation : Translation
    {
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }

        public Caption Caption { get; set; }
    }
}