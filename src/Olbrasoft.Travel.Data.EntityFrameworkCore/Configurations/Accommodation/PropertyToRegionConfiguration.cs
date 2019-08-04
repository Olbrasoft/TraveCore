using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class PropertyToRegionConfiguration : TravelTypeConfiguration<PropertyToRegion>
    {
        public PropertyToRegionConfiguration() : base("PropertiesToRegions")
        {
        }

        public override void Configuration(EntityTypeBuilder<PropertyToRegion> builder)
        {
            builder.HasKey(p => new { p.Id, p.ToId });

            builder.HasOne(rtr => rtr.Creator).WithMany(u => u.PropertiesToRegions).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(propertyToRegion => propertyToRegion.Property).WithMany(property => property.ToRegions)
                .HasForeignKey(propertyToRegion => propertyToRegion.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(propertyToRegion => propertyToRegion.Region).WithMany(r => r.ToProperties)
                .HasForeignKey(propertyToRegion => propertyToRegion.ToId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}