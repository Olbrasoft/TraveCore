using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization
{
    public abstract class TranslationConfiguration<TLocalized> : Configurations.TravelTypeConfiguration<TLocalized> where TLocalized : Translation
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
            ConfigureTranslation(builder);
        }

        public abstract void ConfigureTranslation(EntityTypeBuilder<TLocalized> builder);
    }
}