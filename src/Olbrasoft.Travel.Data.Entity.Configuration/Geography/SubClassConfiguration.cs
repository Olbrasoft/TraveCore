using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Geography
{
    public class SubClassConfiguration : NameConfiguration<SubClass>
    {
        public SubClassConfiguration() : base("SubClasses")
        {
        }

        public override void GeographyConfiguration(EntityTypeBuilder<SubClass> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}