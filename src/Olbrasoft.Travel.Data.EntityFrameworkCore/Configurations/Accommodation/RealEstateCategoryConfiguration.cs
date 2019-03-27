using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class RealEstateCategoryConfiguration : TravelTypeConfiguration<RealEstateCategory>
    {
        public override void Configuration(EntityTypeBuilder<RealEstateCategory> builder)
        {
            builder.ToTable("Categories", nameof(Accommodation));
            builder.HasIndex(typeOfAccommodation => typeOfAccommodation.ExpediaId).IsUnique();
            builder.HasOne(p => p.SuggestionCategory).WithMany(p => p.RealEstateTypes)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}