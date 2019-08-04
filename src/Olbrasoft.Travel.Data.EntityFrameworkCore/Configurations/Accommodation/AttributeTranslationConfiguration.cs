using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class AttributeTranslationConfiguration : Localization.TranslationConfiguration<AttributeTranslation>
    {
        public AttributeTranslationConfiguration() : base("AttributesTranslations")
        {
        }

        public override void ConfigureTranslation(EntityTypeBuilder<AttributeTranslation> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(255).IsRequired();

            builder.HasOne(localizedAttribute => localizedAttribute.Attribute)
                .WithMany(attribute => attribute.LocalizedAttributes)
                .HasForeignKey(localizedAttribute => localizedAttribute.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedAttribute => localizedAttribute.Language)
                .WithMany(language => language.AttributesTranslations).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedAttribute => localizedAttribute.Creator).WithMany(user => user.AttributesTranslations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}