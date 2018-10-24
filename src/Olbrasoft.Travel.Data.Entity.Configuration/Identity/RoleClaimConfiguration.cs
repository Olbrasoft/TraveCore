using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Identity;
using Olbrasoft.TravelCore.Data.Entity.Configuration;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Identity
{
    public class RoleClaimConfiguration:IdentityConfiguration<RoleClaim>
    {
        public RoleClaimConfiguration() : base("RolesClaims")
        {
        }

        public override void Configuration(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasKey(p => new {p.Id });
        }
    }
}