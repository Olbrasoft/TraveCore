using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Data.Transfer.Object.Property
{
    public class PathToHotelImage
    {
        // ReSharper disable once InconsistentNaming
        [Key]
        public int EANHotelID { get; set; }

        // ReSharper disable once InconsistentNaming
        [StringLength(300)]
        public string URL { get; set; }

    }
}