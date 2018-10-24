using Microsoft.EntityFrameworkCore;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public interface ITravelContext
    {
        DbSet<T> Set<T>() where T : class;
    }
}