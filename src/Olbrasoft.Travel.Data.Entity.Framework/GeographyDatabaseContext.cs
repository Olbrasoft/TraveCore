using Microsoft.EntityFrameworkCore;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Geography;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class GeographyDatabaseContext : TravelDatabaseContext, IGeographyContext
    {
        public DbSet<TypeOfRegion> TypesOfRegions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SubClass> SubClasses { get; set; }
        public DbSet<RegionToType> RegionsToTypes { get; set; }
        public DbSet<RegionToRegion> RegionsToRegions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var regionType in (RegionType[])Enum.GetValues(typeof(RegionType)))
            {
                builder.Entity<TypeOfRegion>().HasData(new TypeOfRegion
                {
                    Id = (int)regionType,
                    Name = Enum.GetName(typeof(RegionType), regionType),
                    Description = regionType.GetDescription(),
                    CreatorId = 1
                });
            }
        }
    }


  


}