using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.TravelCore.Expedia.Affiliate.Network.Data.Transfer.Object.Geography
{
    public class CityNeighborhood : IHaveRegionIdRegionName
    {
        // ReSharper disable once InconsistentNaming
        [Key]
        public long RegionID { get; set; }
        [Required]
        [StringLength(255)]
        public string RegionName { get; set; }
        [Required]
        public string Coordinates { get; set; }
    }
}
