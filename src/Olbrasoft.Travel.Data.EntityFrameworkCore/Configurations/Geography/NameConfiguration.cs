using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Geography
{
    public abstract class NameConfiguration<TEntity> : TravelTypeConfiguration<TEntity> where TEntity : HaveName
    {
        protected NameConfiguration(string table) : base(table)
        {
        }

        public override void Configuration(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            ConfigureName(builder);
        }

        public abstract void ConfigureName(EntityTypeBuilder<TEntity> builder);
    }
}