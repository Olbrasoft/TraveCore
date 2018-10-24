using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Identity;
using Olbrasoft.TravelCore.Data.Entity.Configuration;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
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