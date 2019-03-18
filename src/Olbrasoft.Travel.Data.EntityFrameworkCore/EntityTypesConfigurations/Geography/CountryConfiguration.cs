using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Geography
{
    public class CountryConfiguration : TravelTypeConfiguration<Country>
    {
        public CountryConfiguration() : base("Countries")
        {
        }

        public override void Configuration(EntityTypeBuilder<Country> builder)
        {
            builder.Property(p => p.Code).HasMaxLength(2);

            builder.HasIndex(country => country.Id).IsUnique();

            builder.HasIndex(country => country.Code).IsUnique();

            //builder.HasOne(country => country.Creator).WithMany(user => user.Countries).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(country => country.Region).WithOne(region => region.ExpandingInformationAboutCountry)
                .HasForeignKey<Country>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}