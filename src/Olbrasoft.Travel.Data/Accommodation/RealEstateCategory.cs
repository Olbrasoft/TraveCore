using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Suggestion;

namespace Olbrasoft.Travel.Data.Accommodation
{
    [Table("Categories")]
    public class RealEstateCategory : OwnerCreatorInfoAndCreator, IHaveExpediaId<int>, IHaveSuggestionCategory
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Real%20estate%20type
    {
        public int ExpediaId { get; set; } = int.MinValue;

        public virtual ICollection<LocalizedRealEstateCategory> LocalizedRealEstateTypes { get; set; }

        public int SuggestionCategoryId { get; set; }

        // public virtual ICollection<RealEstate> Accommodations { get; set; }
        public SuggestionCategory SuggestionCategory { get; set; }
    }
}