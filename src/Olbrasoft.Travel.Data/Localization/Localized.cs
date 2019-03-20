using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Localization
{
    public class Localized : OwnerCreatorIdAndCreator, ILocalized
    {
        [Key]
        [Column(Order = 2)]
        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}