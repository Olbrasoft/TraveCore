using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class PropertyToAttributeConfiguration : TravelTypeConfiguration<PropertyToAttribute>
    {
        public PropertyToAttributeConfiguration() : base("PropertiesToAttributes")
        {
        }

        public override void Configuration(EntityTypeBuilder<PropertyToAttribute> builder)
        {
            builder.HasKey(p => new { AccommodationId = p.PropertyId, p.AttributeId, p.LanguageId });

            builder.HasOne(ata => ata.Creator).WithMany(u => u.PropertiesToAttributes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ata => ata.Language).WithMany(l => l.PropertiesToAttributes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ata => ata.Attribute).WithMany(a => a.AccommodationsToAttributes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}