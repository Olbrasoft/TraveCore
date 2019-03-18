using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation
{
    public abstract class LocalizedAccommodationTypeConfiguration<TLocalizedAccommodation> : TravelTypeConfiguration<TLocalizedAccommodation> where TLocalizedAccommodation : Localized
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Localized%20Accommodation%20type%20%20Configuration
    {
  
        public override void Configuration(EntityTypeBuilder<TLocalizedAccommodation> builder)
        {
            builder.HasKey(p => new { p.Id, p.LanguageId });
            ConfigureLocalizedAccommodation(builder);
        }

        public abstract void ConfigureLocalizedAccommodation(EntityTypeBuilder<TLocalizedAccommodation> builder);
    }
}