using GeoAPI.Geometries;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Geography;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class RealEstate : OwnerCreatorIdAndCreator, IHaveExpediaId<int>
    //https://en.wikipedia.org/wiki/Real_estate
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Real%20estate
    {
        public RealEstate()
        {
            LocalizedAccommodations = new HashSet<LocalizedRealEstate>();

            LocalizedDescriptionsOfAccommodations = new HashSet<LocalizedDescription>();

            PhotosOfAccommodations = new HashSet<Photo>();

            TypesOfRooms = new HashSet<Room>();

            AccommodationsToAttributes = new HashSet<RealEstateToAttribute>();
        }

        public int SequenceNumber { get; set; }

        public decimal StarRating { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string AdditionalAddress { get; set; }

        [Required]
        public IPoint CenterCoordinates { get; set; }

        [ForeignKey(nameof(RealEstateType))]
        public int TypeId { get; set; }

        public int CountryId { get; set; }

        [ForeignKey(nameof(Airport))]
        public int? AirportId { get; set; }

        public int ChainId { get; set; }

        public int ExpediaId { get; set; } = int.MinValue;

        public Country Country { get; set; }

        public RealEstateType RealEstateType { get; set; }

        public Chain Chain { get; set; }

        public Airport Airport { get; set; }

        public ICollection<LocalizedRealEstate> LocalizedAccommodations { get; set; }

        public ICollection<LocalizedDescription> LocalizedDescriptionsOfAccommodations { get; set; }

        public ICollection<Photo> PhotosOfAccommodations { get; set; }

        public ICollection<Room> TypesOfRooms { get; set; }

        public ICollection<RealEstateToAttribute> AccommodationsToAttributes { get; set; }
    }
}