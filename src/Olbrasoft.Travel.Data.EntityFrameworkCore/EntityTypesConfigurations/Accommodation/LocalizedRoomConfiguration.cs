using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation
{
    public class LocalizedRoomConfiguration : LocalizedAccommodationTypeConfiguration<LocalizedRoom>
    {
        public override void ConfigureLocalizedAccommodation(EntityTypeBuilder<LocalizedRoom> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.Type)
                .WithMany(typeOfRoom => typeOfRoom.LocalizedRooms)
                .HasForeignKey(localizedTypeOfRoom => localizedTypeOfRoom.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.Creator).WithMany(u => u.LocalizedRooms)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.Language).WithMany(l => l.LocalizedRoomTypes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}