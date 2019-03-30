using System.ComponentModel;

namespace Olbrasoft.Travel.Suggestion
{
    public enum SuggestionCategories
    {
        [Description("Cities/Areas")]
        AreasCities = 1,

        Properties,

        Landmarks,

        [Description("Airports/Stations")]
        AirportsStations
    }
}