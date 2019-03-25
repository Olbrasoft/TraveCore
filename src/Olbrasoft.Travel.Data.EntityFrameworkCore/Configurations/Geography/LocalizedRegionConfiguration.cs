using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public class LocalizedRegionConfiguration : LocalizedConfiguration<LocalizedRegion>
    {
        public override void ConfigureLocalized(EntityTypeBuilder<LocalizedRegion> builder)
        {
            builder.HasIndex(p => p.Name);

            builder.HasOne(lr => lr.Creator).WithMany(user => user.LocalizedRegions).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lr => lr.Language).WithMany(l => l.LocalizedRegions).OnDelete(DeleteBehavior.Restrict);
        }
    }
}