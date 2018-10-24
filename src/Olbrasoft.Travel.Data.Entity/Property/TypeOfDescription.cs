using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Property
{
    public class TypeOfDescription : BaseName
    {
        public virtual ICollection<LocalizedDescriptionOfAccommodation> LocalizedDescriptionsOfAccommodations { get; set; }
    }
}