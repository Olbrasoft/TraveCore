using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Geography;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class RegionsCenterImporter : Importer<RegionCenter>
    {
        public RegionsCenterImporter(IProvider provider, IParserFactory parserFactory, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, parserFactory, repositoryFactory, sharedProperties, logger)
        {
        }

        public override void Import(string path)
        {
            LoadData(path);

            var expediaIdsToIds = ImportRegions(ExpediaDataTransferObjects, RepositoryFactory.Regions(), CreatorId);

            ImportLocalizedRegions(ExpediaDataTransferObjects,
                RepositoryFactory.Localized<RegionTranslation>(), expediaIdsToIds, DefaultLanguageId,
                CreatorId);

            ExpediaDataTransferObjects = null;
        }

        private IReadOnlyDictionary<long, int> ImportRegions(
            IEnumerable<RegionCenter> regionsCenter,
            IRegionsRepository repository,
            int creatorId
        )
        {
            LogBuild<Region>();
            var regions = BuildRegions(regionsCenter, creatorId);
            var count = regions.Length;
            LogAssembled(count);

            if (count <= 0) return repository.ExpediaIdsToIds;

            LogSave<Region>();
            repository.BulkSave(regions, r => r.Coordinates, r => r.SubtypeId);
            LogSaved<Region>();

            return repository.ExpediaIdsToIds;
        }

        private static Region[] BuildRegions(
            IEnumerable<RegionCenter> expediaEntities,
            int creatorId
        )
        {
            var regions = new Queue<Region>();
            foreach (var eanEntity in expediaEntities)
            {
                var region = new Region
                {
                    CenterCoordinates = CreatePoint(eanEntity.CenterLatitude, eanEntity.CenterLongitude),
                    ExpediaId = eanEntity.RegionID,
                    CreatorId = creatorId
                };

                region.CenterCoordinates.SRID = 4326;

                regions.Enqueue(region);
            }
            return regions.ToArray();
        }
    }
}