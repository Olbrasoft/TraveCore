namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Data.Transfer.Object.Geography
{
    public interface IHaveRegionIdRegionName : IHaveRegionId
    {
        string RegionName { get; set; }
    }
}