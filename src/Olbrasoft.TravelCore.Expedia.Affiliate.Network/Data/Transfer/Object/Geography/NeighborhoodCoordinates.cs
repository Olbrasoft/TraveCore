namespace Olbrasoft.TravelCore.Expedia.Affiliate.Network.Data.Transfer.Object.Geography
{
    /// <summary>
    /// https://support.ean.com/hc/en-us/articles/115005784405-V3-Database-Files-Geography-Data
    /// File Name: NeighborhoodCoordinatesList.txt
    /// Zip File Name: https://www.ian.com/affiliatecenter/include/V2/new/NeighborhoodCoordinatesList.zip
    /// This file contains a list of neighborhood and their matching RegionID.
    /// The Coordinates field is a colon delimited list of Latitude; Longitude values.
    /// </summary>
    public class NeighborhoodCoordinates : CityNeighborhood
    {
    }
}