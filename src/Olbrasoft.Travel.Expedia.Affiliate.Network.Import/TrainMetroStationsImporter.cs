using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository;
using Olbrasoft.Travel.Data.Repository.Geography;
using Olbrasoft.Travel.Expedia.Affiliate.Network.Data.Transfer.Object.Geography;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal class TrainMetroStationsImporter : Importer<TrainMetroStationCoordinates>
    {
        public TrainMetroStationsImporter(IProvider provider, IParserFactory parserFactory, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, parserFactory, factoryOfRepositories, sharedProperties, logger)
        {
        }

        public override void Import(string path)
        {
            LoadData(path);

            var eanIdsToIds = ImportRegions(EanDataTransferObjects, FactoryOfRepositories.Regions(), CreatorId);

            ImportLocalizedRegions(EanDataTransferObjects, FactoryOfRepositories.OfLocalized<LocalizedRegion>(), eanIdsToIds,
                DefaultLanguageId, CreatorId);

            ImportRegionsToTypes(EanDataTransferObjects, FactoryOfRepositories.RegionsToTypes(), eanIdsToIds,
                FactoryOfRepositories.GeographyNamesRepository<TypeOfRegion>().GetId("TrainStation"),
                FactoryOfRepositories.GeographyNamesRepository<SubClass>().GetId("train"), CreatorId);

            EanDataTransferObjects = null;
        }

        private void ImportRegionsToTypes(
            IEnumerable<TrainMetroStationCoordinates> trainsMetroStationCoordinates,
            IRegionsToTypesRepository repository,
            IReadOnlyDictionary<long, int> eanIdsToIds,
            int typeOfRegionTrainStationId,
            int subClassTrainId,
            int creatorId
            )
        {
            LogBuild<RegionToType>();

            var regionsToTypes = BuildRegionsToTypes(trainsMetroStationCoordinates, eanIdsToIds,
                typeOfRegionTrainStationId, subClassTrainId, creatorId);

            var count = regionsToTypes.Length;

            LogAssembled(count);

            if (count <= 0) return;

            LogSave<RegionToType>();
            repository.BulkSave(regionsToTypes);
            LogSaved<RegionToType>();
        }

        private IReadOnlyDictionary<long, int> ImportRegions(
            IEnumerable<TrainMetroStationCoordinates> trainsMetroStationCoordinates,
            IRegionsRepository repository,
            int creatorId
            )
        {
            LogBuild<Region>();
            var regions = BuildRegions(trainsMetroStationCoordinates, creatorId);
            var count = regions.Length;
            LogAssembled(count);

            if (count <= 0) return repository.EanIdsToIds;

            LogSave<Region>();
            repository.BulkSave(regions, r => r.Coordinates);
            LogSaved<Region>();

            return repository.EanIdsToIds;
        }
    }
}