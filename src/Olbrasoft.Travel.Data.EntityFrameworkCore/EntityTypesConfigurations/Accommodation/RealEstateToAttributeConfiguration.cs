using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation
{
    public class RealEstateToAttributeConfiguration : TravelTypeConfiguration<RealEstateToAttribute>
    {
        public RealEstateToAttributeConfiguration() : base("RealEstatesToAttributes")
        {
        }

        public override void Configuration(EntityTypeBuilder<RealEstateToAttribute> builder)
        {
            builder.HasKey(p => new { AccommodationId = p.RealEstateId, p.AttributeId, p.LanguageId });
            // builder.Property(p => p.Text).HasMaxLength(800);

            builder.HasOne(ata => ata.Creator).WithMany(u => u.AccommodationsToAttributes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ata => ata.Language).WithMany(l => l.RealEstatesToAttributes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ata => ata.Attribute).WithMany(a => a.AccommodationsToAttributes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}