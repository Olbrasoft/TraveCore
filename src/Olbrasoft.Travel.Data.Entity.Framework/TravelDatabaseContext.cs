using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Olbrasoft.Travel.Data.Entity.Configuration;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public abstract class TravelDatabaseContext : DbContext, ITravelContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EntityConfigurationWithSchemaName<>).Assembly);

         
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