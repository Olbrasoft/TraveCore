using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.IO;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.IO
{
    public class PathToPhotoConfiguration : TravelTypeConfiguration<PathToPhoto>
    {
        public PathToPhotoConfiguration() : base("PathsToPhotos")
        {
        }

        public override void Configuration(EntityTypeBuilder<PathToPhoto> builder)
        {
            builder.HasIndex(pathToPhoto => pathToPhoto.Path).IsUnique();

            // builder.Property(p => p.Path).HasMaxLength(300).IsRequired();
        }
    }
}