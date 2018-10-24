using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Globalization
{
    public class LocalizedRegion : Localized
    {
        public virtual string Name { get; set; }

        public string LongName { get; set; }

        public virtual Region Region { get; set; }
    }
}