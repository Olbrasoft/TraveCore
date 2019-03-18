using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public class SubtypeConfiguration : NameConfiguration<Subtype>
    {
        public SubtypeConfiguration() : base("Subtypes")
        {
        }

        public override void ConfigureName(EntityTypeBuilder<Subtype> builder)
        {
            builder.HasIndex(subtype => subtype.Name).IsUnique();
            builder.HasIndex(subtype => subtype.Description).IsUnique();

            builder.HasMany(subtype => subtype.Regions).WithOne(region => region.Subtype)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Property(subtype => subtype.Description).HasMaxLength(50).IsRequired();
            //builder.HasMany(subtype => subtype.Regions).WithOne(p => p.Subtype).IsRequired();
        }
    }
}