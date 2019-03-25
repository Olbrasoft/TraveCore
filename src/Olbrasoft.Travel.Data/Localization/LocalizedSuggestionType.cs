using System.ComponentModel.DataAnnotations;
using Olbrasoft.Data;

namespace Olbrasoft.Travel.Data.Localization
{
    public class LocalizedSuggestionType : Localized, IHaveLabel, IHaveType<SuggestionType>
    {
        [Required]
        [MaxLength(255)]
        public string Label { get; set; }

        public SuggestionType Type { get; set; }
    }
}