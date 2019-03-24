using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Localization
{
    public abstract class Localized : OwnerCreatorInfoAndCreator, IHaveLanguageId
    {
        [Key]
        [Column(Order = 2)]
        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}