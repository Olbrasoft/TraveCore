namespace Olbrasoft.TravelCore.Expedia.Affiliate.Network.Data.Transfer.Object.Geography
{

    public interface IHaveRegionIdRegionNameRegionNameLong
    {
        // ReSharper disable once InconsistentNaming
        long RegionID { get; set; }
        string RegionName { get; set; }
        string RegionNameLong { get; set; }
    }
}