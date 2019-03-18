using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation
{
    public abstract class ManyToManyConfiguration<TEntity> : TravelTypeConfiguration<TEntity>
        where TEntity : ManyToMany
    {
        protected ManyToManyConfiguration(string table): base(table) 
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