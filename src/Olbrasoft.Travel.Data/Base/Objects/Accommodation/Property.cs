using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeoAPI.Geometries;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    /// <summary>
    /// Accommodation property
    /// </summary>
    [Table("Properties")]
    public class Property : OwnerCreatorInfoAndCreator, IHaveExpediaId<int>
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Accommodation%20properties
    {
        public Property()
        {
            PropertiesTranslations = new HashSet<PropertyTranslation>();

            DescriptionsTranslations = new HashSet<DescriptionTranslation>();

            Photos = new HashSet<Photo>();

            Rooms = new HashSet<Room>();

            PropertiesToAttributes = new HashSet<PropertyToAttribute>();
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

        [ForeignKey(nameof(PropertyType))]
        public int CategoryId { get; set; }

        public int CountryId { get; set; }

        [ForeignKey(nameof(Airport))]
        public int? AirportId { get; set; }

        public int ChainId { get; set; }

        public int ExpediaId { get; set; } = int.MinValue;

        public Country Country { get; set; }

        public PropertyType PropertyType { get; set; }

        public Chain Chain { get; set; }

        public Airport Airport { get; set; }

        public ICollection<PropertyTranslation> PropertiesTranslations { get; set; }

        public ICollection<DescriptionTranslation> DescriptionsTranslations { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<PropertyToAttribute> PropertiesToAttributes { get; set; }

        public ICollection<PropertyToRegion> ToRegions { get; set; }
    }
}