using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Identity;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
{
    public class UserConfiguration : IdentityConfiguration<User>
    {
        public UserConfiguration() : base("Users")
        {
        }

        public override void Configuration(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Email).HasMaxLength(256);

            builder.Property(user => user.UserName).HasMaxLength(256).IsRequired();

            builder.HasIndex(user => user.UserName).HasName("UserNameIndex").IsUnique();

            //builder.HasMany<Membership>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();



            //builder.HasMany(user => user.Claims).WithRequired().HasForeignKey(uc => uc.UserId);

            //builder.HasMany(user => user.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
        }
    }
}