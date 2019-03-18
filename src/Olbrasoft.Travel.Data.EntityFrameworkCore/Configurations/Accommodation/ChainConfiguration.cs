using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class ChainConfiguration : TravelTypeConfiguration<Chain>
    {
        public override void Configuration(EntityTypeBuilder<Chain> builder)
        {
            builder.HasIndex(p => p.ExpediaId).IsUnique();

            builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
        }
    }
}