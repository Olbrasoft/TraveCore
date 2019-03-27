using System.ComponentModel;

namespace Olbrasoft.Travel.Geography
{
    public enum RegionSubtypes
    {
        [Description("World")]
        World = 1,

        [Description("Continent")]
        Continent = 2,

        [Description("Country")]
        Country = 3,

        [Description("Province (State)")]
        Province = 4,

        [Description("Multi-Region (within a country)")]
        MultiRegion = 5,

        [Description("Multi-City (Vicinity)")]
        MultiCity = 6,

        [Description("City")]
        City = 7,

        [Description("Neighborhood")]
        Neighborhood = 8,

        [Description("Point of Interest")]
        PointOfInterest = 9,

        [Description("Point of Interest Shadow")]
        PointOfInterestShadow = 10,

        [Description("Airport")]
        Airport = 11,

        [Description("Train Station")]
        TrainStation = 12
    }
}