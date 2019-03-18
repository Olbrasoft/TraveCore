using System.Collections.Generic;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class RealEstateType : OwnerCreatorIdAndCreator, IHaveExpediaId<int>
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Real%20estate%20type
    {
        public int ExpediaId { get; set; } = int.MinValue;

        public virtual ICollection<LocalizedRealEstateType> LocalizedPropertyTypes { get; set; }

      // public virtual ICollection<RealEstate> Accommodations { get; set; }
    }
}