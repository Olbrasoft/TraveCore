﻿using System;
using System.Collections.Generic;
using System.IO;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Repository;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal abstract class BasePhotosRelationalToAccommodationImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsEanIdsToIds;

        protected IReadOnlyDictionary<int, int> AccommodationsEanIdsToIds
        {
            get =>

                _accommodationsEanIdsToIds ?? (_accommodationsEanIdsToIds =
                    FactoryOfRepositories.MappedProperties<Accommodation>().EanIdsToIds);

            set => _accommodationsEanIdsToIds = value;
        }

        private IReadOnlyDictionary<string, int> _pathsToIds;

        protected IReadOnlyDictionary<string, int> PathsToIds
        {
            get =>
                _pathsToIds ?? (_pathsToIds = FactoryOfRepositories.PathsToPhotos().PathsToIds);

            set => _pathsToIds = value;
        }

        private IReadOnlyDictionary<string, int> _extensionsToIds;

        protected IReadOnlyDictionary<string, int> ExtensionsToIds
        {
            get =>
                _extensionsToIds ?? (_extensionsToIds = FactoryOfRepositories.FilesExtensions().ExtensionsToIds);

            set => _extensionsToIds = value;
        }

        protected HashSet<PhotoOfAccommodation> PhotosOfAccommodations = new HashSet<PhotoOfAccommodation>();

        protected BasePhotosRelationalToAccommodationImporter(IProvider provider, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, factoryOfRepositories, sharedProperties, logger)
        {
        }

        protected bool TryBuildPhotoOfAccommodation(string[] items, int urlIndex, out PhotoOfAccommodation photoOfAccommodation)
        {
            var url = items[urlIndex].Trim();

            if (string.IsNullOrEmpty(url) ||
                !int.TryParse(items[0], out var eanHotelId) ||
                !AccommodationsEanIdsToIds.TryGetValue(eanHotelId, out var accommodationId) ||
                !PathsToIds.TryGetValue(ParsePath(url), out var pathToPhotoId) ||
                !ExtensionsToIds.TryGetValue(RemoveDots(Path.GetExtension(url).ToLower()),
                    out var fileExtensionId)
                )
            {
                photoOfAccommodation = null;
                return false;
            }

            photoOfAccommodation = new PhotoOfAccommodation
            {
                AccommodationId = accommodationId,
                PathToPhotoId = pathToPhotoId,
                FileName = RemovePostFix(url),
                FileExtensionId = fileExtensionId,
                CreatorId = CreatorId,
            };

            if (items.Length > 7 && items[7] == "1") photoOfAccommodation.IsDefault = true;

            return true;
        }

        public override void Dispose()
        {
            AccommodationsEanIdsToIds = null;
            PathsToIds = null;
            PhotosOfAccommodations = null;
            ExtensionsToIds = null;

            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}