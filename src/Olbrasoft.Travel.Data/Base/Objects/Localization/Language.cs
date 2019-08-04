using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Base.Objects.Localization
{
    public class Language : OwnerCreatorInfoAndCreator
    {
        [Required]
        [MaxLength(5)]
        [MinLength(5)]
        public string ExpediaCode { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Regions%20translations
        public virtual ICollection<RegionTranslation> RegionsTranslations { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Property%20types%20translations
        public virtual ICollection<PropertyTypeTranslation> PropertyTypesTranslations { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Properties%20translations
        public virtual ICollection<PropertyTranslation> PropertiesTranslations { get; set; }

        public virtual ICollection<DescriptionTranslation> DescriptionsTranslations { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Captions%20translations
        public virtual ICollection<CaptionTranslation> CaptionsTranslations { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Rooms%20translations
        public virtual ICollection<RoomTranslation> RoomsTranslations { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Attributes%20translations
        public virtual ICollection<AttributeTranslation> AttributesTranslations { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Properties%20To%20Attributes
        public virtual ICollection<PropertyToAttribute> PropertiesToAttributes { get; set; }
    }
}