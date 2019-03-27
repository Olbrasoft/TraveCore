using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Olbrasoft.Travel.Data.Suggestion;

namespace Olbrasoft.Travel.Data.Geography
{
    public class RegionSubtype : HaveName, IHaveSuggestionCategory
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public ICollection<Region> Regions { get; set; }

        public int? SuggestionCategoryId { get; set; }

        public SuggestionCategory SuggestionCategory { get; set; }
    }
}