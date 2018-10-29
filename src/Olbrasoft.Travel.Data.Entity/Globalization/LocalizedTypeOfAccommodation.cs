using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Globalization
{
    public class LocalizedTypeOfAccommodation : Localized
    {
        public virtual string Name { get; set; }

        public virtual TypeOfAccommodation TypeOfAccommodation { get; set; }
    }
}