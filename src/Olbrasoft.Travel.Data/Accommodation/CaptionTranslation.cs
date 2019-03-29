using Olbrasoft.Travel.Data.Localization;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class CaptionTranslation : Translation
    {
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }

        public Caption Caption { get; set; }
    }
}