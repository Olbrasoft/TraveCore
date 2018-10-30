using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Globalization
{
    public class LocalizedTypeOfRoom : Localized
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual TypeOfRoom TypeOfRoom { get; set; }
    }
}