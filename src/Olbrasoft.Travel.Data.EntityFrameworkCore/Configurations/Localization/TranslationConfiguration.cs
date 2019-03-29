using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization
{
    public abstract class TranslationConfiguration<TLocalized> : TravelTypeConfiguration<TLocalized> where TLocalized : Translation
    {
        protected TranslationConfiguration()
        {
        }

        protected TranslationConfiguration(string table) : base(table)
        {
        }

        public override void Configuration(EntityTypeBuilder<TLocalized> builder)
        {
            builder.HasKey(p => new { p.Id, p.LanguageId });
            ConfigureLocalized(builder);
        }

        public abstract void ConfigureLocalized(EntityTypeBuilder<TLocalized> builder);
    }
}