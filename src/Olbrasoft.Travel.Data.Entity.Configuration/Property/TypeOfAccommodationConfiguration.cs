using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class TypeOfAccommodationConfiguration : PropertyConfiguration<TypeOfAccommodation>
    {
        public TypeOfAccommodationConfiguration() : base("TypesOfAccommodations")
        {
        }

        public override void Configuration(EntityTypeBuilder<TypeOfAccommodation> builder)
        {
            builder.HasIndex(typeOfAccommodation => typeOfAccommodation.EanId).IsUnique();
        }
    }
}