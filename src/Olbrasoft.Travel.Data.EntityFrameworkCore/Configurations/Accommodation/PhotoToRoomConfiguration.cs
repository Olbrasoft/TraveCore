using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class PhotoToRoomConfiguration : ManyToManyConfiguration<PhotoToRoom>
    {
        public PhotoToRoomConfiguration() : base("PhotosToRooms")
        {
        }

        public override void PropertyConfiguration(EntityTypeBuilder<PhotoToRoom> builder)
        {
            builder.HasOne(p => p.Photo).WithMany(p => p.ToTypesOfRooms).HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Room).WithMany(p => p.PhotosToRooms)
                .HasForeignKey(p => p.ToId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Creator).WithMany(u => u.PhotosToRooms)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}