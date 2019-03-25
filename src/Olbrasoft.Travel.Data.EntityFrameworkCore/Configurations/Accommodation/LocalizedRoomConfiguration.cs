using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class LocalizedRoomConfiguration : LocalizedConfiguration<LocalizedRoom>
    {
        public override void ConfigureLocalized(EntityTypeBuilder<LocalizedRoom> builder)
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