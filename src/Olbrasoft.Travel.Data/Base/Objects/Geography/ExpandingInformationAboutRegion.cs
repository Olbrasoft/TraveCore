using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Base.Objects.Geography
{
    public abstract class ExpandingInformationAboutRegion : OwnerCreatorInfoAndCreator, IAdditionalRegionInfo
    {
        [Required]
        [MaxLength(3)]
        public string Code { get; set; }

        public Region Region { get; set; }
    }
}