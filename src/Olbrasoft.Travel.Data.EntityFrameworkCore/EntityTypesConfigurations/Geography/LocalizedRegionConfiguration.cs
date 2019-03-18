using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography
{
    public class LocalizedRegionConfiguration : TravelTypeConfiguration<LocalizedRegion>
    {
       public override void Configuration(EntityTypeBuilder<LocalizedRegion> builder)
        {
            builder.HasKey(p => new { p.Id, p.LanguageId });

            builder.HasOne(lr => lr.Region).WithMany(r => r.LocalizedRegions).HasForeignKey(p=>p.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(lr => lr.Language).WithMany(l => l.LocalizedRegions).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lr => lr.Creator).WithMany(user => user.LocalizedRegions).OnDelete(DeleteBehavior.Restrict);
        }
    }
}