using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Property;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class PropertyDatabaseContext : TravelDatabaseContext, IPropertyContext
    {
        public DbSet<TypeOfAccommodation> TypesOfAccommodations { get; set; }
        public DbSet<Chain> Chains { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<TypeOfDescription> TypesOfDescriptions { get; set; }
        public DbSet<Caption> Captions { get; set; }
        public DbSet<PhotoOfAccommodation> PhotosOfAccommodations { get; set; }
        public DbSet<TypeOfRoom> TypesOfRooms { get; set; }
        public DbSet<PhotoOfAccommodationToTypeOfRoom> PhotosOfAccommodationsToTypesOfRooms { get; set; }
        public DbSet<TypeOfAttribute> TypesOfAttributes { get; set; }
        public DbSet<SubTypeOfAttribute> SubTypesOfAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var attributeType in (AttributeType[])Enum.GetValues(typeof(AttributeType)))
            {
                builder.Entity<TypeOfAttribute>().HasData(new TypeOfAttribute
                {
                    Id = (int)attributeType,
                    Name = Enum.GetName(typeof(AttributeType), attributeType),
                    CreatorId = 3
                });
            }

            foreach (var attributeSubType in (AttributeSubType[])Enum.GetValues(typeof(AttributeSubType)))
            {
                builder.Entity<SubTypeOfAttribute>().HasData(new SubTypeOfAttribute
                {
                    Id = (int)attributeSubType,
                    Name = Enum.GetName(typeof(AttributeSubType), attributeSubType),
                    CreatorId = 3
                });
            }
        }
    }
}