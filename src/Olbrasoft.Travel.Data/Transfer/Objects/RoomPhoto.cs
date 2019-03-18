using System.Collections.Generic;
using System.Linq;

namespace Olbrasoft.Travel.Data.Transfer.Objects
{
    public class RoomPhoto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }

        public IEnumerable<int> RoomIds
        {
            get { return PhotosToRooms.Select(p => p.RoomId); }
        }

        public IEnumerable<PhotoToRoom> PhotosToRooms { get; set; }
    }
}