using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.TravelCore.Data.Entity.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Configuration.Identity
{
    public class RoleConfiguration : IdentityConfiguration<Role>
    {
        public RoleConfiguration() : base("Roles")
        {
        }

        public override void Configuration(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();
            builder.HasIndex(p => p.Name).HasName("RoleNameIndex").IsUnique();
        }
    }
}