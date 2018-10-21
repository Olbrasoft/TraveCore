namespace Olbrasoft.TravelCore.Expedia.Affiliate.Network.Data.Transfer.Object.Geography
{
    public interface IHaveRegionIdRegionName : IHaveRegionId
    {
        string RegionName { get; set; }
    }
}