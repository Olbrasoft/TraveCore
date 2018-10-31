using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class PhotoOfAccommodationToTypeOfRoomConfiguration : ManyToManyConfiguration<PhotoOfAccommodationToTypeOfRoom>
    {
        public PhotoOfAccommodationToTypeOfRoomConfiguration() : base("PhotosOfAccommodationsToTypesOfRooms")
        {
        }

        public override void PropertyConfiguration(EntityTypeBuilder<PhotoOfAccommodationToTypeOfRoom> builder)
        {

            builder.HasOne(p => p.PhotoOfAccommodation).WithMany(p => p.ToTypesOfRooms).HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.TypeOfRoom).WithMany(p => p.PhotosOfAccommodationsToTypesOfRooms)
                .HasForeignKey(p => p.ToId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Creator).WithMany(u => u.PhotosOfAccommodationsToTypesOfRooms)
                .OnDelete(DeleteBehavior.Restrict);

          
        }
    }
}