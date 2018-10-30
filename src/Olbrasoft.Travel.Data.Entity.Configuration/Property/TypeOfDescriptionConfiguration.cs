using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class TypeOfDescriptionConfiguration : NameConfiguration<TypeOfDescription>
    {
        public TypeOfDescriptionConfiguration() : base("TypesOfDescriptions")
        {
        }

        public override void PropertyConfiguration(EntityTypeBuilder<TypeOfDescription> builder)
        {
            builder.HasIndex(p => p.Name).IsUnique();

            builder.HasOne(tod => tod.Creator).WithMany(user => user.TypesOfDescriptions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}