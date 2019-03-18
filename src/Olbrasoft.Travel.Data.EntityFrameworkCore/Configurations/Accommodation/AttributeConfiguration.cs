using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class AttributeConfiguration : TravelTypeConfiguration<Attribute>
    {
        public override void Configuration(EntityTypeBuilder<Attribute> builder)
        {
            builder.HasOne(attribute => attribute.Type).WithMany(toa => toa.Attributes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(attribute => attribute.Subtype).WithMany(toa => toa.Attributes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}