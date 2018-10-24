using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class LanguageConfiguration : GlobalizationConfiguration<Language>
    {
        public LanguageConfiguration() : base("Languages")
        {
        }

        public override void Configuration(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.EanLanguageCode).IsUnique();

            builder.HasOne(l => l.Creator).WithMany(u => u.Languages);

            builder.Property(p => p.EanLanguageCode).HasMaxLength(5).IsRequired();

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.DateAndTimeOfCreation).HasDefaultValueSql("getutcdate()");
        }
    }
}