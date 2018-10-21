using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.TravelCore.Data.Entity.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Configuration.Identity
{
    public class UserClaimConfiguration : IdentityConfiguration<UserClaim>
    {
        public UserClaimConfiguration() : base("UsersClaims")
        {
        }

        public override void Configuration(EntityTypeBuilder<UserClaim> builder)
        {
        }
    }
}