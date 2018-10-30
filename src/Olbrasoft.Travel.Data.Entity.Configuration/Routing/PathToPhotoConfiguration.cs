using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Routing;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Routing
{
    public class PathToPhotoConfiguration : RoutingConfiguration<PathToPhoto>
    {
        public PathToPhotoConfiguration() : base("PathsToPhotos")
        {
        }

        public override void Configuration(EntityTypeBuilder<PathToPhoto> builder)
        {
            builder.HasIndex(pathToPhoto => pathToPhoto.Path).IsUnique();

            builder.Property(p => p.Path).HasMaxLength(300).IsRequired();
        }
    }
}