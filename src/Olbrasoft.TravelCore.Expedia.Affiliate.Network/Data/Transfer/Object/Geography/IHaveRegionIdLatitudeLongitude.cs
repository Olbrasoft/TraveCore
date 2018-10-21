namespace Olbrasoft.TravelCore.Expedia.Affiliate.Network.Data.Transfer.Object.Geography
{
    public interface IHaveRegionIdLatitudeLongitude : IHaveRegionId
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}