using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class LocalizedDescriptionOfAccommodationConfiguration : GlobalizationConfiguration<LocalizedDescriptionOfAccommodation>
    {
        public LocalizedDescriptionOfAccommodationConfiguration() : base("LocalizedDescriptionsOfAccommodations")
        {
        }

        public override void Configuration(EntityTypeBuilder<LocalizedDescriptionOfAccommodation> builder)
        {
            builder.Property(p => p.Text).IsRequired();

            builder.HasKey(p => new { p.AccommodationId, p.TypeOfDescriptionId, p.LanguageId });

            builder.Property(p => p.DateAndTimeOfCreation).HasDefaultValueSql("getutcdate()");

            builder.HasOne(d => d.Creator).WithMany(u => u.LocalizedDescriptionsOfAccommodations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Language).WithMany(l => l.LocalizedDescriptionsOfAccommodations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.TypeOfDescription).WithMany(tod => tod.LocalizedDescriptionsOfAccommodations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}