using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class PropertyTranslation : Translation
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Translation%20Real%20estate
    {
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [MaxLength(80)]
        public string Location { get; set; }

        [MaxLength(10)]
        public string CheckInTime { get; set; }

        [MaxLength(10)]
        public string CheckOutTime { get; set; }

        public Property Property { get; set; }
    }
}