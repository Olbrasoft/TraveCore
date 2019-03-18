namespace Olbrasoft.Travel.Providers.Expedia.DataTransfer
{
    public interface IHaveRegionIdRegionName : IHaveRegionId
    {
        string RegionName { get; set; }
    }
}