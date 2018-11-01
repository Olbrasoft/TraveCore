using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class LocalizedAttributeConfiguration : LocalizedConfiguration<LocalizedAttribute>
    {
        public LocalizedAttributeConfiguration() : base("LocalizedAttributes")
        {
        }

        public override void GlobalizationConfiguration(EntityTypeBuilder<LocalizedAttribute> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(255).IsRequired();

            builder.HasOne(localizedAttribute => localizedAttribute.Attribute)
                .WithMany(attribute => attribute.LocalizedAttributes)
                .HasForeignKey(localizedAttribute => localizedAttribute.Id).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(localizedAttribute => localizedAttribute.Language)
                .WithMany(language => language.LocalizedAttributes).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedAttribute => localizedAttribute.Creator).WithMany(user => user.LocalizedAttributes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}