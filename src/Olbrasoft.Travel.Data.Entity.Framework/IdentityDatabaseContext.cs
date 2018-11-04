using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Olbrasoft.Travel.Data.Entity.Configuration;
using Olbrasoft.Travel.Data.Entity.Identity;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class IdentityDatabaseContext : DbContext, IIdentityContext
    {
       
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EntityConfigurationWithSchemaName<>).Assembly);

            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = nameof(GeographyDatabaseContext)
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 3,
                UserName = nameof(PropertyDatabaseContext)
            });
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