using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Geography
{
    public class Subtype : HaveName, ICanHaveSuggestionType
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public ICollection<Region> Regions { get; set; }

        public int? SuggestionTypeId { get; set; }

        public SuggestionType SuggestionType { get; set; }
    }
}