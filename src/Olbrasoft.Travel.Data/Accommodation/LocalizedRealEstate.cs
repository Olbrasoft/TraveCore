using Olbrasoft.Travel.Data.Localization;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class LocalizedRealEstate : Localized
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Localized%20Real%20estate
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

        public virtual RealEstate RealEstate { get; set; }
    }
}