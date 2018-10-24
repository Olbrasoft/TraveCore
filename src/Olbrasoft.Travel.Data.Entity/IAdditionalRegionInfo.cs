using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity
{
    public interface IAdditionalRegionInfo
    {
        string Code { get; set; }
        Region Region { get; set; }
       // ICollection<Property.Accommodation> Accommodations { get; set; }
    }
}