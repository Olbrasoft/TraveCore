using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.IO
{
    public class FileExtension : OwnerCreatorIdAndCreator
    {
        [Required]
        [MaxLength(50)]
        public string Extension { get; set; }

        public virtual ICollection<Photo> PhotosOfAccommodations { get; set; }
    }
}