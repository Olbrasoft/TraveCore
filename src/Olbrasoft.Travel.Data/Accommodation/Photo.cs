using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class Photo : OwnerCreatorInfoAndCreator
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Real%20Estate%20Photo
    {
        [Required]
        [ForeignKey(nameof(Property))]
        public int RealEstateId { get; set; }

        public int PathToPhotoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FileName { get; set; }

        public int FileExtensionId { get; set; }

        public bool IsDefault { get; set; }

        public int? CaptionId { get; set; }

        public Property Property { get; set; }

        public PathToPhoto PathToPhoto { get; set; }

        public FileExtension FileExtension { get; set; }

        public Caption Caption { get; set; }

        public ICollection<PhotoToRoom> ToTypesOfRooms { get; set; }
    }
}