using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.IO;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.IO
{
    public class FileExtensionConfiguration : TravelTypeConfiguration<FileExtension>
    {
        public override void Configuration(EntityTypeBuilder<FileExtension> builder)
        {
            builder.HasIndex(fe => fe.Extension).IsUnique();

            //builder.Property(p => p.Extension).HasMaxLength(50).IsRequired();
        }
    }
}