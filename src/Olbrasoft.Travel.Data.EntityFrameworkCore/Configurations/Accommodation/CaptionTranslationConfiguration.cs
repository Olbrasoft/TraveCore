using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class CaptionTranslationConfiguration : Localization.TranslationConfiguration<CaptionTranslation>
    {
        public CaptionTranslationConfiguration() : base("CaptionsTranslations")
        {
        }

        public override void ConfigureTranslation(EntityTypeBuilder<CaptionTranslation> builder)
        {
            builder.HasOne(localizedCaption => localizedCaption.Creator).WithMany(user => user.CaptionsTranslations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedCaption => localizedCaption.Language)
                .WithMany(language => language.CaptionsTranslations).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedCaption => localizedCaption.Caption).WithMany(caption => caption.LocalizedCaptions)
                .HasForeignKey(localizedCaption => localizedCaption.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}