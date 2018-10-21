using Microsoft.EntityFrameworkCore;
using Olbrasoft.TravelCore.Data.Entity.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Framework
{
    public interface IIdentityContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
    }
}