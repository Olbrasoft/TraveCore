using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography
{
    public class ContinentConfiguration : TravelTypeConfiguration<Continent>
    {
        public override void Configuration(EntityTypeBuilder<Continent> builder)
        {
            builder.Property(p => p.Code).HasMaxLength(2);

            builder.HasIndex(continent => continent.Id).IsUnique();

            builder.HasIndex(continent => continent.Code).IsUnique();

            builder.HasOne(continent => continent.Creator).WithMany(user => user.Continents).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(continent => continent.Region).WithOne(region => region.ExpandingInformationAboutContinent)
                .HasForeignKey<Continent>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}