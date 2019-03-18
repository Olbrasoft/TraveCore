using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class RoomConfiguration : TravelTypeConfiguration<Room>
    {
        public override void Configuration(EntityTypeBuilder<Room> builder)
        {
            builder.HasOne(tor => tor.Creator).WithMany(u => u.TypesOfRooms).OnDelete(DeleteBehavior.Restrict);
        }
    }
}