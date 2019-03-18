using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations
{
    public abstract class TravelTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IHaveDateAndTimeOfCreation
    {
        protected string Schema { get; }
        protected string Table { get; }

        protected TravelTypeConfiguration(string schema, string table)
        {
            Schema = schema;
            Table = table;
        }

        protected TravelTypeConfiguration(string table) : this(BuildSchema(), table)
        {
        }

        protected TravelTypeConfiguration() : this(BuildSchema(), BuildTable())
        {
        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(Table, Schema);
            //builder.Property(entity => entity.Created).HasDefaultValueSql("GetUtcDate()");
            Configuration(builder);
        }

        public abstract void Configuration(EntityTypeBuilder<TEntity> builder);

        public static string BuildTable()
        {
            return $"{typeof(TEntity).Name}s";
        }

        public static string BuildSchema()
        {
            var ns = typeof(TEntity).Namespace;
            return ns != null ? ns.Substring(ns.LastIndexOf('.') + 1) : string.Empty;
        }
    }
}