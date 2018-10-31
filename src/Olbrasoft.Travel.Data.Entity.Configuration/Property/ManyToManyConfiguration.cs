using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public abstract class ManyToManyConfiguration<TEntity> : CreatorConfiguration<TEntity>
        where TEntity : ManyToMany
    {
        protected ManyToManyConfiguration(string tableName) : base(tableName)
        {
        }

        public override void Configuration(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => new { p.Id, p.ToId });
            PropertyConfiguration(builder);
        }

        public abstract void PropertyConfiguration(EntityTypeBuilder<TEntity> builder);
    }
}