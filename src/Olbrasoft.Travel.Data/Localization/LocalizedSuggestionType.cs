using Olbrasoft.Data;

namespace Olbrasoft.Travel.Data.Localization
{
    public class LocalizedSuggestionType : Localized, IHaveLabel, IHaveType<SuggestionType>
    {
        public string Label { get; set; }
        public SuggestionType Type { get; set; }
    }
}