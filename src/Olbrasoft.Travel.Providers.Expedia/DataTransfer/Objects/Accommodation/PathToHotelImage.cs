using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Accommodation
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