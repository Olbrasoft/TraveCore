

using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Globalization
{
    public class LocalizedAttribute : Localized
    {
        public string Description { get; set; }

        public Attribute Attribute { get; set; }
    }
}
