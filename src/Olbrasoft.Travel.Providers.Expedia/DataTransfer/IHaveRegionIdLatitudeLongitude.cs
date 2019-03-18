namespace Olbrasoft.Travel.Providers.Expedia.DataTransfer
{
    public interface IHaveRegionIdLatitudeLongitude : IHaveRegionId
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}