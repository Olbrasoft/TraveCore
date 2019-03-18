using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class RealEstateTypeConfiguration : TravelTypeConfiguration<RealEstateType>
    {
        public override void Configuration(EntityTypeBuilder<RealEstateType> builder)
        {
            builder.HasIndex(typeOfAccommodation => typeOfAccommodation.ExpediaId).IsUnique();
        }
    }
}