using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public abstract class LocalizedConfiguration<TEntity> : GlobalizationConfiguration<TEntity> where TEntity : Localized
    {
        protected LocalizedConfiguration(string tableName) : base(tableName)
        {
        }

        public override void Configuration(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => new { p.Id, p.LanguageId });
            GlobalizationConfiguration(builder);
        }

        public abstract void GlobalizationConfiguration(EntityTypeBuilder<TEntity> builder);
    }
}