using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public class RegionTranslationConfiguration : Localization.TranslationConfiguration<RegionTranslation>
    {
        public RegionTranslationConfiguration() : base("RegionsTranslations")
        {
        }

        public override void ConfigureTranslation(EntityTypeBuilder<RegionTranslation> builder)
        {
            builder.HasIndex(p => p.Name);

            builder.HasOne(lr => lr.Creator).WithMany(user => user.LocalizedRegions).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lr => lr.Language).WithMany(l => l.RegionsTranslations).OnDelete(DeleteBehavior.Restrict);
        }
    }
}