using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Accommodation
{
    [Table("PropertyTypesTranslations")]
    public class PropertyTypeTranslation : Translation
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Translation%20Real%20estate%20type
    {
        public virtual string Name { get; set; }

        public virtual PropertyType PropertyType { get; set; }
    }
}