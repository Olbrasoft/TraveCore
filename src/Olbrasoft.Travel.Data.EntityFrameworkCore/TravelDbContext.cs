using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Accommodation;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Identity;
using Olbrasoft.Travel.Geography;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore
{
    public class TravelDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private static User User => new User { Id = 1, UserName = nameof(TravelDbContext) };

        private static IEnumerable<RegionSubtype> Subtypes =>
            from regionType in (RegionSubtypes[])Enum.GetValues(typeof(RegionSubtypes))
            select new RegionSubtype
            {
                Id = (int)regionType,
                Name = Enum.GetName(typeof(RegionSubtypes), regionType),
                Description = regionType.GetDescription(),
                CreatorId = 1
            };

        private static IEnumerable<AttributeType> AttributeTypes =>
            from attributeType in
                (TypesOfAttribute[])Enum.GetValues(typeof(TypesOfAttribute))
            select new AttributeType
            {
                Id = (int)attributeType,
                Name = Enum.GetName(typeof(TypesOfAttribute), attributeType),
                CreatorId = 1
            };

        private static IEnumerable<AttributeSubtype> AttributeSubtypes =>
            from attributeSubType in (SubtypesOfAttribute[])Enum.GetValues(typeof(SubtypesOfAttribute))
            select new AttributeSubtype
            {
                Id = (int)attributeSubType,
                Name = Enum.GetName(typeof(SubtypesOfAttribute), attributeSubType),
                CreatorId = 1
            };

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(TravelTypeConfiguration<>).Assembly);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var property = entityType.FindProperty("Created");
                if (property != null && property.PropertyInfo.PropertyType == typeof(DateTime))
                {
                    builder.Entity(entityType.ClrType).Property(typeof(DateTime), "Created")
                        .HasDefaultValueSql("GetUtcDate()");
                }
            }

            builder.Entity<User>().HasData(User);

            builder.Entity<RegionSubtype>().HasData(Subtypes);

            builder.Entity<AttributeType>().HasData(AttributeTypes);

            builder.Entity<AttributeSubtype>().HasData(AttributeSubtypes);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("TravelCoreConnectionString");
            optionsBuilder.UseSqlServer(connectionString, b => b.UseNetTopologySuite());
        }
    }
}