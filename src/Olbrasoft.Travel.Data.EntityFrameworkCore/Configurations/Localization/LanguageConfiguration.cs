using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization
{
    public class LanguageConfiguration : TravelTypeConfiguration<Language>
    {
        public override void Configuration(EntityTypeBuilder<Language> builder)
        {
            builder.HasIndex(p => p.ExpediaCode).IsUnique();

            builder.Property(e => e.Id).ValueGeneratedNever();
        }
    }
}