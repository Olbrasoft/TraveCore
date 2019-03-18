using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class RealEstateConfiguration : TravelTypeConfiguration<RealEstate>
    {
        public override void Configuration(EntityTypeBuilder<RealEstate> builder)
        {
            builder.Property(accommodation => accommodation.ChainId).HasDefaultValue(0);

            builder.HasIndex(accommodation => accommodation.ExpediaId).IsUnique();

            builder.HasOne(accommodation => accommodation.Creator).WithMany(user => user.Accommodations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(accommodation => accommodation.Chain).WithMany(chain => chain.Accommodations)
                .HasForeignKey(p => p.ChainId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(accommodation => accommodation.Country).WithMany(country => country.Accommodations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}