using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Property
{
    public class Caption : OwnerCreatorIdAndCreator
    {
        public virtual ICollection<LocalizedCaption> LocalizedCaptions { get; set; }

       // public virtual ICollection<PhotoOfAccommodation> PhotosOfAccommodations { get; set; }
    }
}