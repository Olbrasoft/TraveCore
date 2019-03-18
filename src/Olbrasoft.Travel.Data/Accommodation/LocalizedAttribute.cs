using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class LocalizedAttribute : Localized
    {
        public string Description { get; set; }

        public Attribute Attribute { get; set; }
    }
}