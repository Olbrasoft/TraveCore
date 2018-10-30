using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Routing;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public interface IRoutingContext
    {
        DbSet<PathToPhoto> PathsToPhotos { get; set; }
        DbSet<FileExtension> FilesExtensions { get; set; }
    }
}