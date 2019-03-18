using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.IO
{
    public class PathToPhoto : OwnerCreatorIdAndCreator
    {
        [Required]
        [MaxLength(300)]
        public string Path { get; set; }

        public virtual ICollection<Photo> AccommodationPhotos { get; set; }
    }
}