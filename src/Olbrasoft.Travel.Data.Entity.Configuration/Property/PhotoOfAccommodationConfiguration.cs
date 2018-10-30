using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class PhotoOfAccommodationConfiguration : CreatorConfiguration<PhotoOfAccommodation>
    {
        public PhotoOfAccommodationConfiguration() : base("PhotosOfAccommodations")
        {
        }

        public override void Configuration(EntityTypeBuilder<PhotoOfAccommodation> builder)
        {
            builder.Property(photoOfAccommodation => photoOfAccommodation.FileName).HasMaxLength(50);

            builder.HasIndex(photoOfAccommodation => new
            {
                photoOfAccommodation.PathToPhotoId,
                photoOfAccommodation.FileName,
                photoOfAccommodation.FileExtensionId
            }).IsUnique();

            builder.HasOne(photoOfAccommodation => photoOfAccommodation.Creator)
                .WithMany(user => user.PhotosOfAccommodations).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(photoOfAccommodation => photoOfAccommodation.PathToPhoto)
                .WithMany(pathToPhoto => pathToPhoto.PhotosOfAccommodations).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(photoOfAccommodation => photoOfAccommodation.FileExtension)
                .WithMany(fileExtension => fileExtension.PhotosOfAccommodations).OnDelete(DeleteBehavior.Restrict);

            // HasRequired(p => p.Accommodation).WithMany(p => p.PhotosOfAccommodations).HasForeignKey(p => p.AccommodationId).WillCascadeOnDelete(true);
        }
    }
}