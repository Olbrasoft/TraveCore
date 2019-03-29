using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class PropertyTranslationConfiguration : Localization.TranslationConfiguration<PropertyTranslation>
    {
        public PropertyTranslationConfiguration() : base("PropertiesTranslations")
        {
        }

        public override void ConfigureTranslation(EntityTypeBuilder<PropertyTranslation> builder)
        {
            builder.HasIndex(p => p.Name);

            builder.HasOne(localizedAccommodation => localizedAccommodation.Language)
                .WithMany(l => l.PropertiesTranslations).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(la => la.Property).WithMany(a => a.PropertiesTranslations).HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedAccommodation => localizedAccommodation.Creator)
                .WithMany(user => user.PropertiesTranslations).OnDelete(DeleteBehavior.Restrict);
        }
    }
}