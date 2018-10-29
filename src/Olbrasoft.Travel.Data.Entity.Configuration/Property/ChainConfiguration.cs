using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class ChainConfiguration : PropertyConfiguration<Chain>
    {
        public ChainConfiguration() : base("Chains")
        {
        }

        public override void Configuration(EntityTypeBuilder<Chain> builder)
        {
            builder.HasIndex(p => p.EanId).IsUnique();

            builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
        }
    }
}