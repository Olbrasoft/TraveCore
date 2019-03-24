using System.ComponentModel;

namespace Olbrasoft.Travel
{
    public enum TypesOfSuggestion
    {
        [Description("Cities/Areas")]
        AreasCities,

        [Description("Properties")]
        RealEstates,

        Landmarks,

        [Description("Airports/Stations")]
        AirportsStations
    }
}