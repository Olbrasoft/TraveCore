using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
{
   public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.ToTable("Memberships","Identity");
            builder.HasKey(p => new {p.UserId, p.RoleId});

            

        }
    }
}
