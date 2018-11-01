using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data
{
    public interface IHaveRooms
    {
        IEnumerable<Room> Rooms { get; set; }
    }
}