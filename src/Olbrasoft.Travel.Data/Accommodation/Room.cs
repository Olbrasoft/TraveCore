using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class Room : OwnerCreatorInfoAndCreator, IHaveExpediaId<int>
    {
        public int RealEstateId { get; set; }

        public int ExpediaId { get; set; } = int.MinValue;

        public virtual RealEstate RealEstate { get; set; }

        public virtual ICollection<LocalizedRoom> LocalizedRooms { get; set; }

        //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Photos%20to%20Rooms
        public virtual ICollection<PhotoToRoom> PhotosToRooms { get; set; }
    }
}