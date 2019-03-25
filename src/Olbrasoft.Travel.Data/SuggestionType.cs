using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data
{
    [Table(nameof(SuggestionType) + "s")]
    public class SuggestionType : OwnerCreatorInfoAndCreator, IHaveAscending, IHaveLocalizedTypes<LocalizedSuggestionType>
    {
        public int Ascending { get; set; }
        public ICollection<LocalizedSuggestionType> LocalizedTypes { get; set; }
    }
}