using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Routing;

namespace Olbrasoft.Travel.Data.Entity.Property
{
    public class PhotoOfAccommodation : OwnerCreatorIdAndCreator
    {
        public int AccommodationId { get; set; }

        public int PathToPhotoId { get; set; }

        public string FileName { get; set; }

        public int FileExtensionId { get; set; }

        public bool IsDefault { get; set; }

        public int? CaptionId { get; set; }

        public Accommodation Accommodation { get; set; }

        public PathToPhoto PathToPhoto { get; set; }

        public FileExtension FileExtension { get; set; }

        public Caption Caption { get; set; }

        //public ICollection<PhotoOfAccommodationToTypeOfRoom> ToTypesOfRooms { get; set; }
    }
}