using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Identity;


namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
{
    public class UserLoginConfiguration : IdentityConfiguration<UserLogin>
    {
        public UserLoginConfiguration() : base("UsersLogins")
        {
            
        }

        public override void Configuration(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(l => new
            {
                l.LoginProvider,
                l.ProviderKey,
                l.UserId
            });
        }
    }
}