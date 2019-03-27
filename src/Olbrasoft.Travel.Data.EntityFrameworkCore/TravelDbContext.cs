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
using Olbrasoft.Travel.Data.Suggestion;
using Olbrasoft.Travel.Suggestion;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore
{
    public class TravelDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        private static User User => new User { Id = 1, UserName = nameof(TravelDbContext) };

        private static IEnumerable<SuggestionCategory> SuggestionTypes =>
            from typesOfSuggestion in (SuggestionCategories[])Enum.GetValues(typeof(SuggestionCategories))
            select new SuggestionCategory
            { Id = (int)typesOfSuggestion, Ascending = (int)typesOfSuggestion, CreatorId = 1 };

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

        private static IEnumerable<RegionSubtype> AddSuggestionTypeToSubtypes(RegionSubtype[] regionSubtypes)
        {
            foreach (var areaCity in regionSubtypes.Where(p => p.Id > 1 && p.Id < 9))
            {
                areaCity.SuggestionCategoryId = (int)SuggestionCategories.AreasCities;
            }

            foreach (var landMark in regionSubtypes.Where(p => p.Id == 9 || p.Id == 10))
            {
                landMark.SuggestionCategoryId = (int)SuggestionCategories.Landmarks;
            }

            foreach (var airportStation in regionSubtypes.Where(p => p.Id > 10))
            {
                airportStation.SuggestionCategoryId = (int)SuggestionCategories.AirportsStations;
            }

            return regionSubtypes;
        }

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

            builder.Entity<SuggestionCategory>().HasData(SuggestionTypes);

            builder.Entity<RegionSubtype>().HasData(AddSuggestionTypeToSubtypes(Subtypes.ToArray()));

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