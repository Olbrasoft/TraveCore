using System;
using System.Collections.Generic;
using System.Text;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;

namespace SpatialLibraryTest
{
    public class Context : DbContext
    {

        public DbSet<SpatialEntity> SpatialEntities { get; set; }

        public Context()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Data Source=DELL-INSPIRO-15;Initial Catalog=TestSpatial;Integrated Security=True;MultipleActiveResultSets=True;ConnectRetryCount=0",
                b => b.UseNetTopologySuite());

        }
    }


    public class SpatialEntity
    {
        public int Id { get; set; }
        public IPoint CoordinatesCenter { get; set; }
        public IPolygon Coordinates { get; set; }

    }
}
