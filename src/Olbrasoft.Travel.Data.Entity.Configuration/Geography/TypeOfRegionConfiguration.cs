using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Geography
{
    public class TypeOfRegionConfiguration : NameConfiguration<TypeOfRegion>
    {
        public override void GeographyConfiguration(EntityTypeBuilder<TypeOfRegion> builder)
        {
            builder.HasIndex(typeOfRegion => typeOfRegion.Name).IsUnique();
            builder.Property(p => p.Description).HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.Description).IsUnique();
        }

        public TypeOfRegionConfiguration() : base("TypesOfRegions")
        {

        }
    }
}