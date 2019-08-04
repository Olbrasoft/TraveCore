using Olbrasoft.Travel.Data.Base.Objects.Geography;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class PropertyToRegion : ManyToMany
    {
        public Region Region { get; set; }
        public Data.Base.Objects.Accommodation.Property Property { get; set; }
    }
}