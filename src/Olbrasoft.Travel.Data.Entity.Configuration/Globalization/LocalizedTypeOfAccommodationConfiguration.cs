using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class LocalizedTypeOfAccommodationConfiguration : LocalizedConfiguration<LocalizedTypeOfAccommodation>
    {
        public LocalizedTypeOfAccommodationConfiguration() : base("LocalizedTypesOfAccommodations")
        {
        }

        public override void GlobalizationConfiguration(EntityTypeBuilder<LocalizedTypeOfAccommodation> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();

            builder.HasOne(p => p.Creator).WithMany(user => user.LocalizedTypesOfAccommodations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Language).WithMany(language => language.LocalizedTypesOfAccommodations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedTypeOfAccommodation => localizedTypeOfAccommodation.TypeOfAccommodation).WithMany(toa => toa.LocalizedTypesOfAccommodations)
                .HasForeignKey(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}