using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class LocalizedRealEstateCategoryConfiguration : LocalizedConfiguration<LocalizedRealEstateCategory>
    {
        public override void ConfigureLocalized(EntityTypeBuilder<LocalizedRealEstateCategory> builder)
        {
            builder.ToTable("LocalizedCategories", nameof(Accommodation));

            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();

            builder.HasOne(p => p.Creator).WithMany(user => user.LocalizedRealEstateCategories)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Language).WithMany(language => language.LocalizedRealEstateTypes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedTypeOfAccommodation => localizedTypeOfAccommodation.Category).WithMany(toa => toa.LocalizedRealEstateTypes)
                .HasForeignKey(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}