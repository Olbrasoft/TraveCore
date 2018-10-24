using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity
{
    public class Localized : OwnerCreatorIdAndCreator, ILocalized
    {
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
    }
}