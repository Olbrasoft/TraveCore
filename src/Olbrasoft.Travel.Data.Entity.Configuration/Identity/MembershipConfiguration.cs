using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Identity;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
{
    public class MembershipConfiguration : IdentityConfiguration<Membership>
    {
        public MembershipConfiguration() : base("Memberships")
        {
        }

        public override void Configuration(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(p => new { p.UserId, p.RoleId });
        }
    }
}