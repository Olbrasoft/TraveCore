

using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Globalization
{
    public class LocalizedCaption : Localized
    {
        public string Text { get; set; }

        public Caption Caption { get; set; }
    }
}