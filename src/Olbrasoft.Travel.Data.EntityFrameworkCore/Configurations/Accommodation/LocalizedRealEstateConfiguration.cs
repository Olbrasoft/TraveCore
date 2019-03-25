using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class LocalizedRealEstateConfiguration : LocalizedConfiguration<LocalizedRealEstate>
    {
        public override void ConfigureLocalized(EntityTypeBuilder<LocalizedRealEstate> builder)
        {
            builder.HasIndex(p => p.Name);

            builder.HasOne(localizedAccommodation => localizedAccommodation.Language)
                .WithMany(l => l.LocalizedRealEstates).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(la => la.RealEstate).WithMany(a => a.LocalizedAccommodations).HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedAccommodation => localizedAccommodation.Creator)
                .WithMany(user => user.LocalizedAccommodations).OnDelete(DeleteBehavior.Restrict);
        }
    }
}