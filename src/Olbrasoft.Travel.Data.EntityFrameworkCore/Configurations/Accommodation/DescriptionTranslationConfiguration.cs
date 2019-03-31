using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class DescriptionTranslationConfiguration : TravelTypeConfiguration<DescriptionTranslation>
    {
        public DescriptionTranslationConfiguration() : base("DescriptionsTranslations")
        {
        }

        public override void Configuration(EntityTypeBuilder<DescriptionTranslation> builder)
        {
            builder.HasKey(p => new { p.PropertyId, p.Id, p.LanguageId });

            builder.HasOne(d => d.Creator).WithMany(u => u.DescriptionsTranslations).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(descriptionTranslation => descriptionTranslation.Description).WithMany(description => description.DescriptionTranslations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(descriptionTranslation => descriptionTranslation.Language)
                .WithMany(language => language.DescriptionsTranslations).OnDelete(DeleteBehavior.Restrict);
        }
    }
}