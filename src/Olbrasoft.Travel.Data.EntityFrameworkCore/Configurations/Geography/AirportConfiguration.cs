using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public class AirportConfiguration : TravelTypeConfiguration<Airport>
    {
        public override void Configuration(EntityTypeBuilder<Airport> builder)
        {
            builder.HasIndex(c => c.Id).IsUnique();

            builder.HasIndex(c => c.Code).IsUnique();

            //builder.Property(p => p.Code).HasMaxLength(3).IsRequired();

            builder.HasOne(c => c.Creator).WithMany(user => user.Airports).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(country => country.Region).WithOne(region => region.ExpandingInformationAboutAirport)
                .HasForeignKey<Airport>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}