using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Property
{
    public class Attribute : OwnerCreatorIdAndCreator, IHaveEanId<int>
    {
        public int TypeOfAttributeId { get; set; }
        public int SubTypeOfAttributeId { get; set; }
        public int EanId { get; set; } = int.MinValue;
        public bool Ban { get; set; }
        public TypeOfAttribute TypeOfAttribute { get; set; }
        public SubTypeOfAttribute SubTypeOfAttribute { get; set; }
        public ICollection<LocalizedAttribute> LocalizedAttributes { get; set; }
        public virtual ICollection<AccommodationToAttribute> AccommodationsToAttributes { get; set; }
    }
}