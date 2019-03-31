using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class RoomsTypesImagesImporter : BasePhotosRelationalToAccommodationImporter
    {
        protected HashSet<PhotoOfRoom> Photos = new HashSet<PhotoOfRoom>();

        public RoomsTypesImagesImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!TryBuildPhotoOfAccommodation(items, 3, out var photoOfAccommodation)) return;

            var photo = new PhotoOfRoom
            {
                AccommodationId = photoOfAccommodation.PropertyId,
                PathId = photoOfAccommodation.PathToPhotoId,
                FileName = photoOfAccommodation.FileName,
                ExtensionId = photoOfAccommodation.FileExtensionId,
                IsDefault = photoOfAccommodation.IsDefault
            };

            Photos.Add(photo);
        }

        public override void Import(string path)
        {
            LoadData(path);

            PhotosOfAccommodations = new HashSet<Photo>(Photos.Select(p => new Photo
            {
                PropertyId = p.AccommodationId,
                PathToPhotoId = p.PathId,
                FileName = p.FileName,
                FileExtensionId = p.ExtensionId,
                CreatorId = CreatorId,
                IsDefault = p.IsDefault
            }));

            var count = PhotosOfAccommodations.Count;

            WriteLog($"Assembled {count} {typeof(Photo)}.");
            if (count <= 0) return;
            LogSave<Photo>();
            RepositoryFactory.PhotosOfAccommodations().BulkSave(PhotosOfAccommodations, p => p.CaptionId, p => p.IsDefault);
            LogSaved<Photo>();
        }

        public override void Dispose()
        {
            Photos = null;
            PhotosOfAccommodations = null;
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}