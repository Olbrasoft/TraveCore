using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class AttributeTranslation : Translation
    {
        public string Description { get; set; }

        public Attribute Attribute { get; set; }
    }
}