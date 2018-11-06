using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Identity;


namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
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


            builder.HasMany<Membership>().WithOne().HasForeignKey(p => p.RoleId).IsRequired();
        }
    }
}