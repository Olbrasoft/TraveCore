using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class PropertyDatabaseContext : TravelDatabaseContext, IPropertyContext
    {
        public DbSet<TypeOfAccommodation> TypesOfAccommodations { get; set; }
        public DbSet<Chain> Chains { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<TypeOfDescription> TypesOfDescriptions { get; set; }
        public DbSet<Caption> Captions { get; set; }
    }
}