using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Geography
{
    public abstract  class NameConfiguration<TEntity> : CreatorConfiguration<TEntity> where TEntity : BaseName
    {
        protected NameConfiguration(string tableName) : base(tableName)
        {
           
        }
        
        public override void Configuration(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            GeographyConfiguration(builder);
        }

        public abstract void GeographyConfiguration(EntityTypeBuilder<TEntity> builder);

    }
}