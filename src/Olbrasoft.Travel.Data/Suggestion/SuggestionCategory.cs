using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Suggestion
{
    [Table("Categories", Schema = nameof(Suggestion))]
    public class SuggestionCategory : OwnerCreatorInfoAndCreator, IHaveAscending, IHaveLocalizedTypes<LocalizedSuggestionCategory>
    {
        public int Ascending { get; set; }
        public ICollection<LocalizedSuggestionCategory> LocalizedSuggestionCategories { get; set; }
        public ICollection<RegionSubtype> RegionSubtypes { get; set; }
        public ICollection<RealEstateCategory> RealEstateTypes { get; set; }
    }
}