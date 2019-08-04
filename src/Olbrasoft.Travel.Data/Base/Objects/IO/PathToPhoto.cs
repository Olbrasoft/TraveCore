using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Base.Objects.IO
{
    public class PathToPhoto : OwnerCreatorInfoAndCreator
    {
        [Required]
        [MaxLength(300)]
        public string Path { get; set; }

        public virtual ICollection<Photo> AccommodationPhotos { get; set; }
    }
}