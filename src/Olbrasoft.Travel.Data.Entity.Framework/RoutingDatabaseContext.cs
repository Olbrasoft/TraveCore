using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Routing;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class RoutingDatabaseContext : TravelDatabaseContext, IRoutingContext
    {
        public DbSet<PathToPhoto> PathsToPhotos { get; set; }
        public DbSet<FileExtension> FilesExtensions { get; set; }
    }
}