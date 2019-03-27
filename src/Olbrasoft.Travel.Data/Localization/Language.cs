using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Geography;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Suggestion;

namespace Olbrasoft.Travel.Data.Localization
{
    public class Language : OwnerCreatorInfoAndCreator
    {
        [Required]
        [MaxLength(5)]
        [MinLength(5)]
        public string ExpediaCode { get; set; }

        public virtual ICollection<LocalizedRegion> LocalizedRegions { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Localized%20Real%20estate%20types
        public virtual ICollection<LocalizedRealEstateCategory> LocalizedRealEstateTypes { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Localized%20Real%20estates
        public virtual ICollection<LocalizedRealEstate> LocalizedRealEstates { get; set; }

        public virtual ICollection<LocalizedDescription> LocalizedDescriptions { get; set; }

        public virtual ICollection<LocalizedCaption> LocalizedCaptions { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Localized%20Room%20Types
        public virtual ICollection<LocalizedRoom> LocalizedRoomTypes { get; set; }

        public virtual ICollection<LocalizedAttribute> LocalizedAttributes { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Real%20estates%20To%20Attributes
        public virtual ICollection<RealEstateToAttribute> RealEstatesToAttributes { get; set; }

        public ICollection<LocalizedSuggestionCategory> LocalizedSuggestionCategories { get; set; }
    }
}