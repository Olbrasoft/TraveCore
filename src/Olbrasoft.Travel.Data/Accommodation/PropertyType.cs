using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Accommodation
{
    [Table("PropertyTypes")]
    public class PropertyType : OwnerCreatorInfoAndCreator, IHaveExpediaId<int>
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Real%20estate%20type
    {
        public int ExpediaId { get; set; } = int.MinValue;

        public virtual ICollection<PropertyTypeTranslation> PropertyTypesTranslations { get; set; }

        public int SuggestionCategoryId { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}