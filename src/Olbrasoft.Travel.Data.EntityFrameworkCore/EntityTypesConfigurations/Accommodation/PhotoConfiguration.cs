using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Accommodation
{
    public class PhotoConfiguration : TravelTypeConfiguration<Photo>
    {
        public override void Configuration(EntityTypeBuilder<Photo> builder)
        {
            //builder.Property(photoOfAccommodation => photoOfAccommodation.FileName).HasMaxLength(50);

            builder.HasIndex(photoOfAccommodation => new
            {
                photoOfAccommodation.PathToPhotoId,
                photoOfAccommodation.FileName,
                photoOfAccommodation.FileExtensionId
            }).IsUnique();

            builder.HasOne(photoOfAccommodation => photoOfAccommodation.Creator)
                .WithMany(user => user.AccommodationPhotos).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(photoOfAccommodation => photoOfAccommodation.PathToPhoto)
                .WithMany(pathToPhoto => pathToPhoto.AccommodationPhotos).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(photoOfAccommodation => photoOfAccommodation.FileExtension)
                .WithMany(fileExtension => fileExtension.PhotosOfAccommodations).OnDelete(DeleteBehavior.Restrict);

            // HasRequired(p => p.RealEstate).WithMany(p => p.AccommodationPhotos).HasForeignKey(p => p.RealEstateId).WillCascadeOnDelete(true);
        }
    }
}