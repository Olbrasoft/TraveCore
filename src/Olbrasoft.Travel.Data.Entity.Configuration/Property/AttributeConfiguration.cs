using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class AttributeConfiguration : CreatorConfiguration<Olbrasoft.Travel.Data.Entity.Property.Attribute>
    {
        public AttributeConfiguration():base("Attributes")
        {
            

            }

        public override void Configuration(EntityTypeBuilder<Attribute> builder)
        {
            builder.HasOne(attribute => attribute.TypeOfAttribute).WithMany(toa => toa.Attributes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(attribute => attribute.SubTypeOfAttribute).WithMany(toa => toa.Attributes)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}