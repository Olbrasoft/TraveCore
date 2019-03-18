using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class LocalizedRealEstateTypeConfiguration : LocalizedAccommodationTypeConfiguration<LocalizedRealEstateType>
    {
        public override void ConfigureLocalizedAccommodation(EntityTypeBuilder<LocalizedRealEstateType> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();

            builder.HasOne(p => p.Creator).WithMany(user => user.LocalizedTypesOfAccommodations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Language).WithMany(language => language.LocalizedRealEstateTypes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedTypeOfAccommodation => localizedTypeOfAccommodation.Type).WithMany(toa => toa.LocalizedPropertyTypes)
                .HasForeignKey(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}