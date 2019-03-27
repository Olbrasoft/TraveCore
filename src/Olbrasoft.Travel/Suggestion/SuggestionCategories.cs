using System.ComponentModel;

namespace Olbrasoft.Travel.Suggestion
{
    public enum SuggestionCategories
    {
        [Description("Cities/Areas")]
        AreasCities = 1,

        [Description("Properties")]
        RealEstates,

        Landmarks,

        [Description("Airports/Stations")]
        AirportsStations
    }
}