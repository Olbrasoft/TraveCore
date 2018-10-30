using Olbrasoft.Travel.Data.Entity.Property;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Entity.Routing
{
    public class FileExtension : OwnerCreatorIdAndCreator
    {
        public string Extension { get; set; }

        public virtual ICollection<PhotoOfAccommodation> PhotosOfAccommodations { get; set; }
    }
}