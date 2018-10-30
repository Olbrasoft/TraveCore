using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public abstract class NameConfiguration<TEntity> : PropertyConfiguration<TEntity> where TEntity : BaseName
    {
        protected NameConfiguration(string tableName) : base(tableName)
        {
        }

        public override void Configuration(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        }

        public abstract void PropertyConfiguration(EntityTypeBuilder<TEntity> builder);
    }
}