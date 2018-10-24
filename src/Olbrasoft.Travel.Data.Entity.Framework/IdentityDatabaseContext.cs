using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Olbrasoft.Travel.Data.Entity.Identity;
using Olbrasoft.Travel.Data.Entity.Configuration;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class IdentityDatabaseContext : DbContext, IIdentityContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EntityConfigurationWithSchemaName<>).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("app.config.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("TravelCoreConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}