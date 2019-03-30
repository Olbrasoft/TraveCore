using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class Room : OwnerCreatorInfoAndCreator, IHaveExpediaId<int>
    {
        public int PropertyId { get; set; }

        public int ExpediaId { get; set; } = int.MinValue;

        public virtual Property Property { get; set; }

        public virtual ICollection<RoomTranslation> LocalizedRooms { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Photos%20to%20Rooms
        public virtual ICollection<PhotoToRoom> PhotosToRooms { get; set; }
    }
}