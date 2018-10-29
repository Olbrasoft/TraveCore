using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class LocalizedAccommodationConfiguration : LocalizedConfiguration<LocalizedAccommodation>
    {
        public LocalizedAccommodationConfiguration() : base("LocalizedAccommodations")
        {
        }

        public override void GlobalizationConfiguration(EntityTypeBuilder<LocalizedAccommodation> builder)
        {
            builder.Property(localizedAccommodation => localizedAccommodation.Location).HasMaxLength(80);

            builder.Property(localizedAccommodation => localizedAccommodation.CheckInTime).HasMaxLength(10);

            builder.Property(localizedAccommodation => localizedAccommodation.CheckOutTime).HasMaxLength(10);

            builder.Property(localizedAccommodation => localizedAccommodation.Name).HasMaxLength(70).IsRequired();

            builder.HasOne(localizedAccommodation => localizedAccommodation.Language)
                .WithMany(l => l.LocalizedAccommodations).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(la => la.Accommodation).WithMany(a => a.LocalizedAccommodations).HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedAccommodation => localizedAccommodation.Creator)
                .WithMany(user => user.LocalizedAccommodations).OnDelete(DeleteBehavior.Restrict);
        }
    }
}