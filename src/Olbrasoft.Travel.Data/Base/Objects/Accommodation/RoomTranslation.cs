using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class RoomTranslation : Translation
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Room Type { get; set; }
    }
}