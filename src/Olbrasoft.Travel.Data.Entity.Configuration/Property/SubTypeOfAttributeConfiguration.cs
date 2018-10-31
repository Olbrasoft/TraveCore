using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class SubTypeOfAttributeConfiguration : NameConfiguration<SubTypeOfAttribute>
    {
        public SubTypeOfAttributeConfiguration() : base("SubTypesOfAttributes")
        {
        }

        public override void PropertyConfiguration(EntityTypeBuilder<SubTypeOfAttribute> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}