using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Geography
{
    public class RegionToRegionConfiguration : GeographyConfiguration<RegionToRegion>
    {
        public RegionToRegionConfiguration() : base("RegionsToRegions")
        {
        }

        public override void Configuration(EntityTypeBuilder<RegionToRegion> builder)
        {
            builder.HasKey(p => new { p.Id, p.ToId });
            builder.HasOne(rtr => rtr.Creator).WithMany(u => u.RegionsToRegions).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(regionToRegion => regionToRegion.Region)
                .WithMany(region => region.ToChildRegions)
                .HasForeignKey(regionToRegion => regionToRegion.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(regionToRegion => regionToRegion.ParentRegion)
                .WithMany(region => region.ToParentRegions).HasForeignKey(regionToRegion => regionToRegion.ToId);
        }
    }
}