using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class LocalizedRegionConfiguration : GlobalizationConfiguration<LocalizedRegion>
    {
        public LocalizedRegionConfiguration() : base("LocalizedRegions")
        {
        }

        public override void Configuration(EntityTypeBuilder<LocalizedRegion> builder)
        {
            builder.HasKey(p => new { p.Id, p.LanguageId });

            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();

            builder.Property(p => p.LongName).HasMaxLength(510);

            builder.HasOne(lr => lr.Region).WithMany(r => r.LocalizedRegions).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(lr => lr.Language).WithMany(l => l.LocalizedRegions).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lr => lr.Creator).WithMany(user => user.LocalizedRegions).OnDelete(DeleteBehavior.Restrict);
        }
    }
}