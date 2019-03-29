using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class PropertyTypeTranslationConfiguration : TranslationConfiguration<PropertyTypeTranslation>
    {
        public override void ConfigureLocalized(EntityTypeBuilder<PropertyTypeTranslation> builder)
        {
            builder.ToTable("PropertyTypesTranslations", nameof(Accommodation));

            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();

            builder.HasOne(p => p.Creator).WithMany(user => user.PropertyTypesTranslations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Language).WithMany(language => language.PropertyTypesTranslations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedTypeOfAccommodation => localizedTypeOfAccommodation.PropertyType).WithMany(toa => toa.LocalizedRealEstateTypes)
                .HasForeignKey(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}