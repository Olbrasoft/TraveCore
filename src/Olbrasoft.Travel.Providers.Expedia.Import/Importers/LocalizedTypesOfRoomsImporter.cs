using System;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class LocalizedTypesOfRoomsImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsExpediaIdsToIds;

        private IReadOnlyDictionary<int, int> AccommodationsExpediaIdsToIds
        {
            get =>

                _accommodationsExpediaIdsToIds ?? (_accommodationsExpediaIdsToIds =
                    RepositoryFactory.MappedProperties<RealEstate>().ExpediaIdsToIds);

            set => _accommodationsExpediaIdsToIds = value;
        }

        private IReadOnlyDictionary<int, int> _eanRoomTypeIdsToIds;

        protected IReadOnlyDictionary<int, int> EanRoomTypeIdsToIds
        {
            get => _eanRoomTypeIdsToIds ??
               (_eanRoomTypeIdsToIds = RepositoryFactory.MappedProperties<Room>().ExpediaIdsToIds);

            set => _eanRoomTypeIdsToIds = value;
        }

        protected Queue<LocalizedRoom> LocalizedTypesOfRooms = new Queue<LocalizedRoom>();

        public LocalizedTypesOfRoomsImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!int.TryParse(items[0], out var eanHotelId) || !AccommodationsExpediaIdsToIds.ContainsKey(eanHotelId)) return;

            if (!int.TryParse(items[1], out var eanRoomTypeId) || !EanRoomTypeIdsToIds.TryGetValue(eanRoomTypeId, out var id)) return;

            var localizedTypeOfRoom = new LocalizedRoom
            {
                Id = id,
                LanguageId = DefaultLanguageId,
                Name = items[4].Trim(),
                Description = items[5].Trim(),
                CreatorId = CreatorId
            };

            LocalizedTypesOfRooms.Enqueue(localizedTypeOfRoom);
        }

        public override void Import(string path)
        {
            LoadData(path);

            LogSave<LocalizedRoom>();
            RepositoryFactory.Localized<LocalizedRoom>().BulkSave(LocalizedTypesOfRooms, 270000);
            LogSaved<LocalizedRoom>();
        }

        public override void Dispose()
        {
            EanRoomTypeIdsToIds = null;
            AccommodationsExpediaIdsToIds = null;
            LocalizedTypesOfRooms = null;

            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}