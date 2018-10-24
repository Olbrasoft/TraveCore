using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Identity;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public interface IIdentityContext
    {
        DbSet<User> Users { get; set; }
       // DbSet<Role> Roles { get; set; }
    }
}