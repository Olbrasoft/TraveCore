using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class LocalizedRealEstateType : Localized
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Localized%20Real%20estate%20type
    {
        public virtual string Name { get; set; }

        public virtual RealEstateType Type { get; set; }
    }
}