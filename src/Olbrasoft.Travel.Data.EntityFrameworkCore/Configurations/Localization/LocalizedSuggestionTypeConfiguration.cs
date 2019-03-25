using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization
{
    public class LocalizedSuggestionTypeConfiguration : LocalizedConfiguration<LocalizedSuggestionType>
    {
        public override void ConfigureLocalized(EntityTypeBuilder<LocalizedSuggestionType> builder)
        {
            builder.HasOne(localizedSuggestionType => localizedSuggestionType.Language)
                .WithMany(language => language.LocalizedSuggestionTypes).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedSuggestionType => localizedSuggestionType.Creator).WithMany(user => user.LocalizedSuggestionTypes)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}