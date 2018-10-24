using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
{
    public class IdentityUserLoginConfiguration: IEntityTypeConfiguration<IdentityUserLogin<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> builder)
        {
            builder.ToTable("UsersLogins", "Identity");
            builder.HasKey(p => new {p.LoginProvider, p.ProviderKey});
        }
    }
}
