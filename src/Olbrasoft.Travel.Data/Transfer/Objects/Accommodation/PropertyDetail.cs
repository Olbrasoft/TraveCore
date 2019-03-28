using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Transfer.Objects.Accommodation
{
    public class PropertyDetail : BasePropertyDto, IHaveRooms, IHaveAttributes
    {
        public string Description { get; set; }

        public string[] Photos { get; set; }

        [Range(typeof(double), "-90", "90")]
        public double Latitude { get; set; }

        [Range(typeof(double), "-180", "180")]
        public double Longitude { get; set; }

        public IEnumerable<RoomDto> Rooms { get; set; }

        public IEnumerable<AttributeDto> Attributes { get; set; }
    }
}