using Microsoft.EntityFrameworkCore;
using Olbrasoft.TravelCore.Data.Entity.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Framework
{
    public class IdentityDatabaseContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserContext<User,int,UserClaim,UserLogin,UserToken>

    {
        public IdentityDatabaseContext() 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          // builder.ApplyConfigurationsFromAssembly()
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.AddFromAssembly(typeof(EntityConfigurationWithSchemaName<>).Assembly);
        //}
    }
}