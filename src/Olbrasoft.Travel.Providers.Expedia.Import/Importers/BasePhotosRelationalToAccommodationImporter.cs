using System;
using System.Collections.Generic;
using System.IO;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal abstract class BasePhotosRelationalToAccommodationImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsExpediaIdsToIds;

        protected IReadOnlyDictionary<int, int> AccommodationsExpediaIdsToIds
        {
            get =>

                _accommodationsExpediaIdsToIds ?? (_accommodationsExpediaIdsToIds =
                    RepositoryFactory.MappedProperties<Property>().ExpediaIdsToIds);

            set => _accommodationsExpediaIdsToIds = value;
        }

        private IReadOnlyDictionary<string, int> _pathsToIds;

        protected IReadOnlyDictionary<string, int> PathsToIds
        {
            get =>
                _pathsToIds ?? (_pathsToIds = RepositoryFactory.PathsToPhotos().PathsToIds);

            set => _pathsToIds = value;
        }

        private IReadOnlyDictionary<string, int> _extensionsToIds;

        protected IReadOnlyDictionary<string, int> ExtensionsToIds
        {
            get =>
                _extensionsToIds ?? (_extensionsToIds = RepositoryFactory.FilesExtensions().ExtensionsToIds);

            set => _extensionsToIds = value;
        }

        protected HashSet<Photo> PhotosOfAccommodations = new HashSet<Photo>();

        protected BasePhotosRelationalToAccommodationImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected bool TryBuildPhotoOfAccommodation(string[] items, int urlIndex, out Photo photo)
        {
            var url = items[urlIndex].Trim();

            if (string.IsNullOrEmpty(url) ||
                !int.TryParse(items[0], out var eanHotelId) ||
                !AccommodationsExpediaIdsToIds.TryGetValue(eanHotelId, out var accommodationId) ||
                !PathsToIds.TryGetValue(ParsePath(url), out var pathToPhotoId) ||
                !ExtensionsToIds.TryGetValue(RemoveDots(Path.GetExtension(url).ToLower()),
                    out var fileExtensionId)
                )
            {
                photo = null;
                return false;
            }

            photo = new Photo
            {
                RealEstateId = accommodationId,
                PathToPhotoId = pathToPhotoId,
                FileName = RemovePostFix(url),
                FileExtensionId = fileExtensionId,
                CreatorId = CreatorId,
            };

            if (items.Length > 7 && items[7] == "1") photo.IsDefault = true;

            return true;
        }

        public override void Dispose()
        {
            AccommodationsExpediaIdsToIds = null;
            PathsToIds = null;
            PhotosOfAccommodations = null;
            ExtensionsToIds = null;

            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}