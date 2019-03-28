using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data
{
    public interface IHaveRooms
    {
        IEnumerable<RoomDto> Rooms { get; set; }
    }
}