using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    public class TypesOfRoomsImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsExpediaIdsToIds;

        private IReadOnlyDictionary<int, int> AccommodationsExpediaIdsToIds
        {
            get => _accommodationsExpediaIdsToIds ?? (
                       _accommodationsExpediaIdsToIds =
                           RepositoryFactory.MappedProperties<Property>().ExpediaIdsToIds);

            set => _accommodationsExpediaIdsToIds = value;
        }

        protected Queue<Room> TypesOfRooms = new Queue<Room>();

        public TypesOfRoomsImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!int.TryParse(items[0], out var eanHotelId) ||
                !AccommodationsExpediaIdsToIds.TryGetValue(eanHotelId, out var accommodationId) ||
                !int.TryParse(items[1], out var ExpediaId)) return;

            var typeOfRoom = new Room
            {
                ExpediaId = ExpediaId,
                PropertyId = accommodationId,
                CreatorId = CreatorId
            };

            TypesOfRooms.Enqueue(typeOfRoom);
        }

        public override void Import(string path)
        {
            LoadData(path);

            if (TypesOfRooms.Count <= 0) return;
            LogSave<Room>();
            RepositoryFactory.MappedProperties<Room>().BulkSave(TypesOfRooms, 270000);
            LogSaved<Room>();
        }

        public override void Dispose()
        {
            AccommodationsExpediaIdsToIds = null;
            TypesOfRooms = null;
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}