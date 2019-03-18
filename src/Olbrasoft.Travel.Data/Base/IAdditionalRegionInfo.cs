using Olbrasoft.Travel.Data.Geography;

namespace Olbrasoft.Travel.Data.Base
{
    public interface IAdditionalRegionInfo
    {
        string Code { get; set; }
        Region Region { get; set; }
       // ICollection<Property.RealEstate> Accommodations { get; set; }
    }
}