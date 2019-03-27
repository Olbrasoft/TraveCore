using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Geography;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class TrainMetroStationsImporter : Importer<TrainMetroStationCoordinates>
    {
        public TrainMetroStationsImporter(IProvider provider, IParserFactory parserFactory, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, parserFactory, repositoryFactory, sharedProperties, logger)
        {
        }

        public override void Import(string path)
        {
            LoadData(path);

            var expediaIdsToIds = ImportRegions(ExpediaDataTransferObjects, RepositoryFactory.Regions(),
                RepositoryFactory.Names<RegionSubtype>().GetId("TrainStation"), CreatorId);

            ImportLocalizedRegions(ExpediaDataTransferObjects, RepositoryFactory.Localized<LocalizedRegion>(), expediaIdsToIds,
                DefaultLanguageId, CreatorId);

            ImportRegionsToSubclasses(ExpediaDataTransferObjects, RepositoryFactory.ManyToMany<RegionToSubclass>(), expediaIdsToIds,
                RepositoryFactory.Names<Subclass>().GetId("train"), CreatorId);

            ExpediaDataTransferObjects = null;
        }

        private void ImportRegionsToSubclasses(
            IEnumerable<TrainMetroStationCoordinates> trainsMetroStationCoordinates,
            IManyToManyRepository<RegionToSubclass> repository,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int subClassTrainId,
            int creatorId
            )
        {
            LogBuild<RegionToSubclass>();

            var regionsToTypes = BuildRegionsToSubclasses(trainsMetroStationCoordinates, expediaIdsToIds,
                subClassTrainId, creatorId);

            var count = regionsToTypes.Length;

            LogAssembled(count);

            if (count <= 0) return;

            LogSave<RegionToSubclass>();
            repository.BulkSave(regionsToTypes);
            LogSaved<RegionToSubclass>();
        }

        private IReadOnlyDictionary<long, int> ImportRegions(
            IEnumerable<TrainMetroStationCoordinates> trainsMetroStationCoordinates,
            IRegionsRepository repository,
            int trainMetroStationSubtypeId,
            int creatorId
            )
        {
            LogBuild<Region>();
            var regions = BuildRegions(trainsMetroStationCoordinates, trainMetroStationSubtypeId, creatorId);
            var count = regions.Length;
            LogAssembled(count);

            if (count <= 0) return repository.ExpediaIdsToIds;

            LogSave<Region>();
            repository.BulkSave(regions, r => r.Coordinates);
            LogSaved<Region>();

            return repository.ExpediaIdsToIds;
        }
    }
}