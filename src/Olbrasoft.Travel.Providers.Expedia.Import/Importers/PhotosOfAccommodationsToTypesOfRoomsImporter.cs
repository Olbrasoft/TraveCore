using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class PhotosOfAccommodationsToTypesOfRoomsImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _typesOfRoomsExpediaIdsToIds;

        protected IReadOnlyDictionary<int, int> TypesOfRoomsExpediaIdsToIds
        {
            get =>
                _typesOfRoomsExpediaIdsToIds ??
                (_typesOfRoomsExpediaIdsToIds = RepositoryFactory.MappedProperties<Room>().ExpediaIdsToIds);

            set => _typesOfRoomsExpediaIdsToIds = value;
        }

        private IReadOnlyDictionary<Tuple<int, string, int>, int> _pathIdsAndFileIdsAndExtensionIdsToIds;

        protected IReadOnlyDictionary<Tuple<int, string, int>, int> PathIdsAndFileIdsAndExtensionIdsToIds
        {
            get => _pathIdsAndFileIdsAndExtensionIdsToIds ?? (_pathIdsAndFileIdsAndExtensionIdsToIds =
                       RepositoryFactory.PhotosOfAccommodations().GetPathIdsAndFileIdsAndExtensionIdsToIds());

            set => _pathIdsAndFileIdsAndExtensionIdsToIds = value;
        }

        private IReadOnlyDictionary<string, int> _pathsToIds;

        public IReadOnlyDictionary<string, int> PathsToIds
        {
            get => _pathsToIds ?? (_pathsToIds = RepositoryFactory.PathsToPhotos().PathsToIds);

            private set => _pathsToIds = value;
        }

        private IReadOnlyDictionary<string, int> _extensionsToIds;

        public IReadOnlyDictionary<string, int> ExtensionsToIds
        {
            get => _extensionsToIds ?? (_extensionsToIds = RepositoryFactory.FilesExtensions().ExtensionsToIds);

            private set => _extensionsToIds = value;
        }

        protected Queue<PhotoToRoom> PhotosOfAccommodationsToTypesOfRooms = new Queue<PhotoToRoom>();

        public PhotosOfAccommodationsToTypesOfRoomsImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            var url = items[3].Trim();

            if (string.IsNullOrEmpty(url) ||
                !PathsToIds.TryGetValue(ParsePath(url), out var pathToPhotoId) ||
                !ExtensionsToIds.TryGetValue(RemoveDots(Path.GetExtension(url).ToLower()),
                    out var fileExtensionId)) return;

            var tup = new Tuple<int, string, int>(pathToPhotoId, RemovePostFix(url), fileExtensionId);
            if (!PathIdsAndFileIdsAndExtensionIdsToIds.TryGetValue(tup, out var photoOfAccommodationId)) return;

            if (!int.TryParse(items[1], out var eanRoomTypeId) ||
                !TypesOfRoomsExpediaIdsToIds.TryGetValue(eanRoomTypeId, out var typeOfRoomId)) return;

            var photoOfAccommodationToTypeOfRoom = new PhotoToRoom
            {
                Id = photoOfAccommodationId,
                ToId = typeOfRoomId,
                CreatorId = CreatorId
            };

            PhotosOfAccommodationsToTypesOfRooms.Enqueue(photoOfAccommodationToTypeOfRoom);
        }

        public override void Import(string path)
        {
            LoadData(path);

            var count = PhotosOfAccommodationsToTypesOfRooms.Count;

            WriteLog($"Assembled {count} {typeof(Photo)}.");

            if (count <= 0) return;
            LogSave<PhotoToRoom>();
            RepositoryFactory.ManyToMany<PhotoToRoom>().BulkSave(PhotosOfAccommodationsToTypesOfRooms);
            LogSaved<PhotoToRoom>();
        }

        public override void Dispose()
        {
            PhotosOfAccommodationsToTypesOfRooms = null;
            PathIdsAndFileIdsAndExtensionIdsToIds = null;
            PathsToIds = null;
            ExtensionsToIds = null;
            TypesOfRoomsExpediaIdsToIds = null;

            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}