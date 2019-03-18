using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public class SubClassConfiguration : NameConfiguration<Subclass>
    {
        public SubClassConfiguration() : base("SubClasses")
        {
        }

        public override void ConfigureName(EntityTypeBuilder<Subclass> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}