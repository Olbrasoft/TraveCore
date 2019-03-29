using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class RoomTranslationConfiguration : TranslationConfiguration<RoomTranslation>
    {
        public RoomTranslationConfiguration() : base("RoomsTranslations")
        {
        }

        public override void ConfigureLocalized(EntityTypeBuilder<RoomTranslation> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.Type)
                .WithMany(typeOfRoom => typeOfRoom.LocalizedRooms)
                .HasForeignKey(localizedTypeOfRoom => localizedTypeOfRoom.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.Creator).WithMany(u => u.RoomsTranslations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.Language).WithMany(l => l.RoomsTranslations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}