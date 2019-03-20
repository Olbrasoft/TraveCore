using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Olbrasoft.Extensions;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Identity;
using Olbrasoft.Travel.Property;
using System;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.Transfer.Objects;
using AttributeType = Olbrasoft.Travel.Data.Accommodation.AttributeType;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore
{
    public class TravelDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbQuery<Suggestion> Suggestions { get; set; }

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

            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = nameof(TravelDbContext)
            });

            foreach (var regionType in (Travel.Geography.SubtypesOfRegion[])Enum.GetValues(typeof(Travel.Geography.SubtypesOfRegion)))
            {
                builder.Entity<Subtype>().HasData(new Subtype
                {
                    Id = (int)regionType,
                    Name = Enum.GetName(typeof(Travel.Geography.SubtypesOfRegion), regionType),
                    Description = regionType.GetDescription(),
                    CreatorId = 1
                });
            }

            foreach (var attributeType in (Property.AttributeType[])Enum.GetValues(typeof(Property.AttributeType)))
            {
                builder.Entity<AttributeType>().HasData(new AttributeType
                {
                    Id = (int)attributeType,
                    Name = Enum.GetName(typeof(Property.AttributeType), attributeType),
                    CreatorId = 1
                });
            }

            foreach (var attributeSubType in (AttributeSubType[])Enum.GetValues(typeof(AttributeSubType)))
            {
                builder.Entity<AttributeSubtype>().HasData(new AttributeSubtype
                {
                    Id = (int)attributeSubType,
                    Name = Enum.GetName(typeof(AttributeSubType), attributeSubType),
                    CreatorId = 1
                });
            }

            //builder.Entity<User>().HasData(new User
            //{
            //    Id = 3,
            //    UserName = nameof(PropertyDatabaseContext)
            //});
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