using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository;
using Olbrasoft.Travel.Data.Repository.Geography;
using Olbrasoft.Travel.Expedia.Affiliate.Network.Data.Transfer.Object.Geography;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal class RegionsCenterImporter : Importer<RegionCenter>
    {
        public RegionsCenterImporter(IProvider provider, IParserFactory parserFactory, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, parserFactory, factoryOfRepositories, sharedProperties, logger)
        {
        }

        public override void Import(string path)
        {
            LoadData(path);

            var eanIdsToIds = ImportRegions(EanDataTransferObjects, FactoryOfRepositories.Regions(), CreatorId);

            ImportLocalizedRegions(EanDataTransferObjects,
                FactoryOfRepositories.OfLocalized<LocalizedRegion>(), eanIdsToIds, DefaultLanguageId,
                CreatorId);

            EanDataTransferObjects = null;
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

            if (count <= 0) return repository.EanIdsToIds;

            LogSave<Region>();
            repository.BulkSave(regions, r => r.Coordinates);
            LogSaved<Region>();

            return repository.EanIdsToIds;
        }

        private static Region[] BuildRegions(IEnumerable<RegionCenter> eanEntities,
            int creatorId
        )
        {
            var regions = new Queue<Region>();
            foreach (var eanEntity in eanEntities)
            {
                var region = new Region
                {
                    CenterCoordinates = CreatePoint(eanEntity.CenterLatitude, eanEntity.CenterLongitude),
                    EanId = eanEntity.RegionID,
                    CreatorId = creatorId
                };

                region.CenterCoordinates.SRID = 4326;

                regions.Enqueue(region);
            }
            return regions.ToArray();
        }
    }
}