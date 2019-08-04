using Olbrasoft.Globalization;

namespace Olbrasoft.Travel.Data.Base.Objects.Localization
{
    public abstract class Translation : OwnerCreatorInfoAndCreator, IHaveLanguageId<int>
    {
        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}