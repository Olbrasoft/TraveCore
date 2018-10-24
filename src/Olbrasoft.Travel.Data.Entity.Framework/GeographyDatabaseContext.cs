using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class GeographyDatabaseContext : TravelDatabaseContext, IGeographyContext
    {
        public DbSet<TypeOfRegion> TypesOfRegions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SubClass> SubClasses { get; set; }
        public DbSet<RegionToType> RegionsToTypes { get; set; }
    }
}