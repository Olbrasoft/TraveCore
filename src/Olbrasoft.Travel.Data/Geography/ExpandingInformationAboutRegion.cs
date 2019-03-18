using Olbrasoft.Travel.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Geography
{
    public abstract class ExpandingInformationAboutRegion : OwnerCreatorIdAndCreator, IAdditionalRegionInfo
    {
        [Required]
        [MaxLength(3)]
        public string Code { get; set; }

        public Region Region { get; set; }
    }
}