using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Routing
{
    public class PathToPhoto : OwnerCreatorIdAndCreator
    {
        public string Path { get; set; }

       public virtual ICollection<PhotoOfAccommodation> PhotosOfAccommodations { get; set; }
    }
}