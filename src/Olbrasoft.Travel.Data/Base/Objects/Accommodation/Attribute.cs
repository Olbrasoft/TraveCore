using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class Attribute : OwnerCreatorInfoAndCreator, IHaveExpediaId<int>
    {
        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        [Required]
        [ForeignKey(nameof(Subtype))]
        public int SubtypeId { get; set; }

        public int ExpediaId { get; set; } = int.MinValue;

        public bool Ban { get; set; }

        [Required]
        public AttributeType Type { get; set; }

        [Required]
        public AttributeSubtype Subtype { get; set; }

        public ICollection<AttributeTranslation> LocalizedAttributes { get; set; }

        public virtual ICollection<PropertyToAttribute> AccommodationsToAttributes { get; set; }
    }
}