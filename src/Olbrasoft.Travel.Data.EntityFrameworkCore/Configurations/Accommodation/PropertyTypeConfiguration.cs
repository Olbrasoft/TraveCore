using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class PropertyTypeConfiguration : TravelTypeConfiguration<PropertyType>
    {
        public override void Configuration(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasIndex(typeOfAccommodation => typeOfAccommodation.ExpediaId).IsUnique();
        }
    }
}