using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class LocalizedRoom : Localized
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Room Type { get; set; }
    }
}