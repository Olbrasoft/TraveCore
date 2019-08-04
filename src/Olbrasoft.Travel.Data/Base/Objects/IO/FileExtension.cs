using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Base.Objects.IO
{
    public class FileExtension : OwnerCreatorInfoAndCreator
    {
        [Required]
        [MaxLength(50)]
        public string Extension { get; set; }

        public virtual ICollection<Photo> PhotosOfAccommodations { get; set; }
    }
}