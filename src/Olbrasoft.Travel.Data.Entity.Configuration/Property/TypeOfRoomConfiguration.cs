using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class TypeOfRoomConfiguration : CreatorConfiguration<TypeOfRoom>
    {
        public TypeOfRoomConfiguration() : base("TypesOfRooms")
        {
        }

        public override void Configuration(EntityTypeBuilder<TypeOfRoom> builder)
        {
            builder.HasOne(tor => tor.Creator).WithMany(u => u.TypesOfRooms).OnDelete(DeleteBehavior.Restrict);
        }
    }
}