using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Olbrasoft.TravelCore.Data.Entity.Configuration
{
    public abstract class EntityConfigurationWithSchemaName<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IHaveDateTimeOfCreation
    {
        protected string SchemaName { get; }
        protected string TableName { get; }

        protected EntityConfigurationWithSchemaName(string schemaName ,string tableName)
        {
            SchemaName = schemaName;
            TableName = tableName;
        }

      

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName, SchemaName);
            builder.Property(entity => entity.DateAndTimeOfCreation).HasDefaultValueSql("getutcdate()");
            Configuration(builder);
        }

        public abstract void Configuration(EntityTypeBuilder<TEntity> builder);
    }
}