using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public class RegionSubtypeConfiguration : NameConfiguration<RegionSubtype>
    {
        public override void ConfigureName(EntityTypeBuilder<RegionSubtype> builder)
        {
            builder.HasIndex(subtype => subtype.Name).IsUnique();
            builder.HasIndex(subtype => subtype.Description).IsUnique();

            builder.HasMany(subtype => subtype.Regions).WithOne(region => region.Subtype)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Property(subtype => subtype.Description).HasMaxLength(50).IsRequired();
            //builder.HasMany(subtype => subtype.Regions).WithOne(p => p.Subtype).IsRequired();
        }

        public RegionSubtypeConfiguration() : base("RegionSubtypes")
        {
        }
    }
}