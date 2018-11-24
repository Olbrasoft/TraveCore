using GeoAPI.Geometries;
using Olbrasoft.Travel.Data.Entity.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Entity.Geography
{
    public class Region : OwnerCreatorIdAndCreator
    {
        public Region()
        {
            RegionsToTypes = new HashSet<RegionToType>();
            LocalizedRegions = new HashSet<LocalizedRegion>();
        }

        [Column(TypeName = "geography")]
        public IPolygon Coordinates { get; set; }

        [Column(TypeName = "geography")]
        public IPoint CenterCoordinates { get; set; }

        public long EanId { get; set; } = long.MinValue;

        public ICollection<RegionToType> RegionsToTypes { get; set; }

        public ICollection<RegionToRegion> ToParentRegions { get; set; }

        public ICollection<RegionToRegion> ToChildRegions { get; set; }

        public ICollection<LocalizedRegion> LocalizedRegions { get; set; }

        public Continent ExpandingInformationAboutContinent { get; set; }

        public Country ExpandingInformationAboutCountry { get; set; }

        public Airport ExpandingInformationAboutAirport { get; set; }
    }
}