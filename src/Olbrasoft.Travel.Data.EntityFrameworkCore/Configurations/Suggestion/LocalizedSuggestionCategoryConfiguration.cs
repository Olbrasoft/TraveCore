using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;
using Olbrasoft.Travel.Data.Suggestion;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Suggestion
{
    public class LocalizedSuggestionCategoryConfiguration : LocalizedConfiguration<LocalizedSuggestionCategory>
    {
        public override void ConfigureLocalized(EntityTypeBuilder<LocalizedSuggestionCategory> builder)
        {
            builder.ToTable("LocalizedCategories", nameof(Suggestion));
        }
    }
}