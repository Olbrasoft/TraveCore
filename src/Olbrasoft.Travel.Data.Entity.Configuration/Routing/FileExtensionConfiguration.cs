using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Routing;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Routing
{
    public class FileExtensionConfiguration : RoutingConfiguration<FileExtension>
    {
        public FileExtensionConfiguration() : base("FilesExtensions")
        {
        }

        public override void Configuration(EntityTypeBuilder<FileExtension> builder)
        {
            builder.HasIndex(fe => fe.Extension).IsUnique();

            builder.Property(p => p.Extension).HasMaxLength(50).IsRequired();
        }
    }
}