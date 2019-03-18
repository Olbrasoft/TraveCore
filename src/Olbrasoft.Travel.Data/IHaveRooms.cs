using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data
{
    public interface IHaveRooms
    {
        IEnumerable<Room> Rooms { get; set; }
    }
}