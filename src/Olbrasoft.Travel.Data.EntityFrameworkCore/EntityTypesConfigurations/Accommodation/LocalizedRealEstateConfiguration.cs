using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation
{
    public class LocalizedRealEstateConfiguration : LocalizedAccommodationTypeConfiguration<LocalizedRealEstate>
    {
  
        public override void ConfigureLocalizedAccommodation(EntityTypeBuilder<LocalizedRealEstate> builder)
        {

            builder.HasOne(localizedAccommodation => localizedAccommodation.Language)
                .WithMany(l => l.LocalizedRealEstates).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(la => la.RealEstate).WithMany(a => a.LocalizedAccommodations).HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedAccommodation => localizedAccommodation.Creator)
                .WithMany(user => user.LocalizedAccommodations).OnDelete(DeleteBehavior.Restrict);
        }
    }
}