using System.Collections.Generic;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data
{
    public class SuggestionType : HaveName, IHaveAscending, IHaveLocalizedTypes<LocalizedSuggestionType>
    {
        public int Ascending { get; set; }
        public ICollection<LocalizedSuggestionType> LocalizedTypes { get; set; }
    }
}