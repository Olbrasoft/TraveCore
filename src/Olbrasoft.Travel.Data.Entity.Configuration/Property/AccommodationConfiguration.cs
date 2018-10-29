using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class AccommodationConfiguration : PropertyConfiguration<Accommodation>
    {
        public AccommodationConfiguration() : base("Accommodations")
        {
        }

        public override void Configuration(EntityTypeBuilder<Accommodation> builder)
        {
            builder.HasIndex(accommodation => accommodation.EanId).IsUnique();

            builder.Property(accommodation => accommodation.CenterCoordinates).IsRequired();

            builder.Property(accommodation => accommodation.AdditionalAddress).HasMaxLength(50);

            builder.Property(accommodation => accommodation.Address).HasMaxLength(50).IsRequired();

            builder.Property(accommodation => accommodation.ChainId).HasDefaultValue(0);

            builder.HasOne(accommodation => accommodation.Chain).WithMany(chain => chain.Accommodations)
                .HasForeignKey(p => p.ChainId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(accommodation => accommodation.Creator).WithMany(user => user.Accommodations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(accommodation => accommodation.Country).WithMany(country => country.Accommodations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}