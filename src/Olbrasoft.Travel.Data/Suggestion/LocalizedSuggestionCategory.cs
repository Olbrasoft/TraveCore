using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Suggestion
{
    //[Table("Categories", Schema = nameof(Suggestion))]
    public class LocalizedSuggestionCategory : Localized, IHaveLabel, IHaveType<SuggestionCategory>
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public SuggestionCategory Category { get; set; }
    }
}