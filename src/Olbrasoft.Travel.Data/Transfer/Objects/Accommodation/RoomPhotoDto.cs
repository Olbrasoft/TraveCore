using System.Collections.Generic;
using System.Linq;

namespace Olbrasoft.Travel.Data.Transfer.Objects.Accommodation
{
    public class RoomPhotoDto : PhotoDto
    {
        public IEnumerable<int> RoomIds
        {
            get { return PhotosToRooms.Select(p => p.RoomId); }
        }

        public IEnumerable<PhotoToRoomDto> PhotosToRooms { get; set; }
    }
}