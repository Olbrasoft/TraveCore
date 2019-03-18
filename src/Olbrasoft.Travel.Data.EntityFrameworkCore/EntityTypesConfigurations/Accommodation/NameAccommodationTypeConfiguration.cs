using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation
{
    public abstract class NameAccommodationTypeConfiguration<TEntity> : TravelTypeConfiguration<TEntity> where TEntity : HaveName
    {
        public override void Configuration(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
        }

        public abstract void NameConfigure(EntityTypeBuilder<TEntity> builder);
    }
}