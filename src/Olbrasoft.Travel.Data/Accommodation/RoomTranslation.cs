using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class RoomTranslation : Translation
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Room Type { get; set; }
    }
}