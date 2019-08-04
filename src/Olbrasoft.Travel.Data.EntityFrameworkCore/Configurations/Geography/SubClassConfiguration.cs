using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public class SubclassConfiguration : NameConfiguration<Subclass>
    {
        public SubclassConfiguration() : base("Subclasses")
        {
        }

        public override void ConfigureName(EntityTypeBuilder<Subclass> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}