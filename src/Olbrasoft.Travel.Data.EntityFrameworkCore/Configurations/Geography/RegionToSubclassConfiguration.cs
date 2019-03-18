using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public class RegionToSubclassConfiguration : TravelTypeConfiguration<RegionToSubclass>
    {
        public override void Configuration(EntityTypeBuilder<RegionToSubclass> builder)
        {
            builder.HasKey(p => new { p.Id, p.ToId });

            builder.HasOne(regionToSubclass => regionToSubclass.Creator).WithMany(user => user.RegionsToSubclasses).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(regionToSubclass => regionToSubclass.Region).WithMany(region => region.ToSubclasses).HasForeignKey(p => p.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(regionToType => regionToType.Subclass).WithMany(subClass => subClass.ToRegions).HasForeignKey(p => p.ToId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}