using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Accommodation
{
    public class RoomType
    {
        // ReSharper disable once InconsistentNaming
        public int EANHotelID { get; set; }

        // ReSharper disable once InconsistentNaming
        public int RoomTypeID { get; set; }

        [StringLength(5)]
        public string LanguageCode { get; set; }

        [StringLength(256)]
        public string RoomTypeImage { get; set; }

        [StringLength(200)]
        public string RoomTypeName { get; set; }

        public string RoomTypeDescription { get; set; }
    }
}