using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Identity;
using Olbrasoft.TravelCore.Data.Entity.Configuration;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
{
    public class UserTokenConfiguration: IdentityConfiguration<UserToken>
    {
        public UserTokenConfiguration() : base("UsersTokens")
        {
        }

        public override void Configuration(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(p=>new {p.UserId,p.LoginProvider,p.Name});
            builder.Property(p => p.Name).HasMaxLength(128).IsRequired();
            builder.Property(p => p.LoginProvider).HasMaxLength(128).IsRequired();

        }
    }
}