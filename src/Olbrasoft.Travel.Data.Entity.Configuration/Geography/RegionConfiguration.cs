using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Geography
{
    public class RegionConfiguration : GeographyConfiguration<Region>
    {
       
        public RegionConfiguration() : base("Regions")
        {
        }

        public override void Configuration(EntityTypeBuilder<Region> builder)
        {
             //builder.HasOne(r => r.Creator).WithMany(u => u.Regions).OnDelete(DeleteBehavior.Cascade).IsRequired();

            //builder.HasOne(p => p.AdditionalCountryProperties).WithOne(country => country.Region).HasForeignKey<Country>(p=>p.Id)
            //    .OnDelete(DeleteBehavior.Cascade);

            //    HasOptional(p => p.AdditionalAirportProperties).WithRequired(p => p.Region).WillCascadeOnDelete(true);
        }
    }
}