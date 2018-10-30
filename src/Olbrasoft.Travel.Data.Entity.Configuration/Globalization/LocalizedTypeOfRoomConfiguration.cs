using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class LocalizedTypeOfRoomConfiguration : LocalizedConfiguration<LocalizedTypeOfRoom>
    {
        public LocalizedTypeOfRoomConfiguration() : base("LocalizedTypesOfRooms")
        {
        }

        public override void GlobalizationConfiguration(EntityTypeBuilder<LocalizedTypeOfRoom> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.TypeOfRoom)
                .WithMany(typeOfRoom => typeOfRoom.LocalizedTypesOfRooms)
                .HasForeignKey(localizedTypeOfRoom => localizedTypeOfRoom.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.Creator).WithMany(u => u.LocalizedTypesOfRooms)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedTypeOfRoom => localizedTypeOfRoom.Language).WithMany(l => l.LocalizedTypesOfRooms)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}