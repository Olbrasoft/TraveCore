using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Geography
{
    public class Subclass : HaveName
    {
        public virtual ICollection<RegionToSubclass> ToRegions { get; set; }

        // public virtual ICollection<RegionToSubClass> RegionsToSubClasses { get; set; }

        // public virtual ICollection<Region> Regions { get; set; }

        // public virtual ICollection<CityToSubClass> CitiesToSubClasses { get; set; }

        // public virtual ICollection<PointOfInterestToSubClass> PointsOfInterestToSubClasses { get; set; }

        //public virtual ICollection<PointOfInterest> PointsOfInterests { get; set; }
    }
}