using GeoAPI.Geometries;
using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Geography
{
    [Table(nameof(Region) + "s", Schema = nameof(Geography))]
    public class Region : OwnerCreatorInfoAndCreator
    {
        public Region()
        {
            LocalizedRegions = new HashSet<LocalizedRegion>();
        }

        [Column(TypeName = "geography")]
        public IPolygon Coordinates { get; set; }

        [Column(TypeName = "geography")]
        public IPoint CenterCoordinates { get; set; }

        public long ExpediaId { get; set; } = long.MinValue;

        //[ForeignKey(nameof(Subtype))]
        public int SubtypeId { get; set; }

        [Required]
        public Subtype Subtype { get; set; }

        public ICollection<RegionToRegion> ToParentRegions { get; set; }

        public ICollection<RegionToRegion> ToChildRegions { get; set; }

        public ICollection<LocalizedRegion> LocalizedRegions { get; set; }

        public ICollection<RegionToSubclass> ToSubclasses { get; set; }

        public Continent ExpandingInformationAboutContinent { get; set; }

        public Country ExpandingInformationAboutCountry { get; set; }

        public Airport ExpandingInformationAboutAirport { get; set; }
    }
}