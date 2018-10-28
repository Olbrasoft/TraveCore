using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public interface IGeographyContext : ITravelContext
    {
        DbSet<TypeOfRegion> TypesOfRegions { get; set; }
        DbSet<Region> Regions { get; set; }
        DbSet<SubClass> SubClasses { get; set; }
        DbSet<RegionToType> RegionsToTypes { get; set; }
        DbSet<RegionToRegion> RegionsToRegions { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Airport> Airports { get; set; }
    }
}