using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class AccommodationToAttributeConfiguration : GlobalizationConfiguration<AccommodationToAttribute>
    {
        public AccommodationToAttributeConfiguration() : base("AccommodationsToAttributes")
        {
        }

        public override void Configuration(EntityTypeBuilder<AccommodationToAttribute> builder)
        {
            builder.HasKey(p => new { p.AccommodationId, p.AttributeId, p.LanguageId });

            builder.Property(p => p.Text).HasMaxLength(800);

            builder.HasOne(ata => ata.Creator).WithMany(u => u.AccommodationsToAttributes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ata => ata.Language).WithMany(l => l.AccommodationsToAttributes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ata => ata.Attribute).WithMany(a => a.AccommodationsToAttributes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}