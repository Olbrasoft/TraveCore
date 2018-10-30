using System;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Repository;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    public class TypesOfRoomsImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsEanIdsToIds;

        private IReadOnlyDictionary<int, int> AccommodationsEanIdsToIds
        {
            get => _accommodationsEanIdsToIds ?? (
                       _accommodationsEanIdsToIds =
                           FactoryOfRepositories.MappedProperties<Accommodation>().EanIdsToIds);

            set => _accommodationsEanIdsToIds = value;
        }

        protected Queue<TypeOfRoom> TypesOfRooms = new Queue<TypeOfRoom>();

        public TypesOfRoomsImporter(IProvider provider, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, factoryOfRepositories, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!int.TryParse(items[0], out var eanHotelId) ||
                !AccommodationsEanIdsToIds.TryGetValue(eanHotelId, out var accommodationId) ||
                !int.TryParse(items[1], out var eanId)) return;

            var typeOfRoom = new TypeOfRoom
            {
                EanId = eanId,
                AccommodationId = accommodationId,
                CreatorId = CreatorId
            };

            TypesOfRooms.Enqueue(typeOfRoom);
        }

        public override void Import(string path)
        {
            LoadData(path);

            if (TypesOfRooms.Count <= 0) return;
            LogSave<TypeOfRoom>();
            FactoryOfRepositories.MappedProperties<TypeOfRoom>().BulkSave(TypesOfRooms, 270000);
            LogSaved<TypeOfRoom>();
        }

        public override void Dispose()
        {
            AccommodationsEanIdsToIds = null;
            TypesOfRooms = null;
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}