using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class TypeOfAttributeConfiguration : NameConfiguration<TypeOfAttribute>
    {
        public TypeOfAttributeConfiguration() : base("TypesOfAttributes")
        {
        }

        public override void PropertyConfiguration(EntityTypeBuilder<TypeOfAttribute> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}