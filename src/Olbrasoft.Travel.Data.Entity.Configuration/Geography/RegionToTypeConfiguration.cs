using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Geography
{
    public class RegionToTypeConfiguration : GeographyConfiguration<RegionToType>
    {
     
        public RegionToTypeConfiguration() : base("RegionsToTypes")
        {
        }

        public override void Configuration(EntityTypeBuilder<RegionToType> builder)
        {
            builder.HasKey(p => new { p.Id, p.ToId });

            builder.HasOne(rtp => rtp.Region).WithMany(region => region.RegionsToTypes).HasForeignKey(p=>p.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(regionToType => regionToType.Creator).WithMany(user => user.RegionsToTypes).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(regionToType => regionToType.TypeOfRegion).WithMany(typeOfRegion => typeOfRegion.RegionsToTypes).HasForeignKey(p => p.ToId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}