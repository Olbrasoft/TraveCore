using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class LocalizedDescriptionConfiguration : TravelTypeConfiguration<LocalizedDescription>
    {
        public override void Configuration(EntityTypeBuilder<LocalizedDescription> builder)
        {
            builder.HasKey(p => new { AccommodationId = p.RealEstateId, TypeOfDescriptionId = p.DescriptionId, p.LanguageId });

            builder.HasOne(d => d.Creator).WithMany(u => u.LocalizedDescriptionsOfAccommodations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Language).WithMany(l => l.LocalizedDescriptions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Description).WithMany(tod => tod.LocalizedDescriptions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}