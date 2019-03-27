using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Accommodation
{
    [Table("LocalizedCategories")]
    public class LocalizedRealEstateCategory : Localized
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Localized%20Real%20estate%20type
    {
        public virtual string Name { get; set; }

        public virtual RealEstateCategory Category { get; set; }
    }
}