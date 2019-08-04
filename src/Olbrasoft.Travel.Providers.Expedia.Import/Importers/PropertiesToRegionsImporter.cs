using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Olbrasoft.Travel.Providers.Expedia.Import.Unit.Tests")]

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class PropertiesToRegionsImporter : Importer<RegionEANHotelIDMapping>
    {
        public PropertiesToRegionsImporter(IProvider provider, IParserFactory parserFactory, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger) : base(provider, parserFactory, repositoryFactory, sharedProperties, logger)
        {
        }

        public override void Import(string path)
        {
            LoadData(path);

            ImportRegionsToProperties(ExpediaDataTransferObjects, RepositoryFactory.ManyToMany<PropertyToRegion>(), RepositoryFactory.Regions().ExpediaIdsToIds, RepositoryFactory.MappedProperties<Property>().ExpediaIdsToIds, CreatorId);
        }

        private void ImportRegionsToProperties(IEnumerable<RegionEANHotelIDMapping> expediaDataTransferObjects
            , IManyToManyRepository<PropertyToRegion> repository,
            IReadOnlyDictionary<long, int> regionExpediaIdsToIds,
            IReadOnlyDictionary<int, int> propertyExpediaIdsToIds,
            int creatorId
            )
        {
            LogBuild<PropertyToRegion>();
            var propertiesToRegions = BuildRegionsToProperties(expediaDataTransferObjects, regionExpediaIdsToIds, propertyExpediaIdsToIds, creatorId);
            LogAssembled(propertiesToRegions.Length);

            LogSave<PropertyToRegion>();
            repository.BulkSave(propertiesToRegions);
            LogSaved<PropertyToRegion>();
        }

        private static PropertyToRegion[] BuildRegionsToProperties(
            IEnumerable<RegionEANHotelIDMapping> expediaDataTransferObjects,
            IReadOnlyDictionary<long, int> regionExpediaIdsToIds,
            IReadOnlyDictionary<int, int> propertyIdsToIds,
            int creatorId
            )
        {
            var propertyToRegions = new Queue<PropertyToRegion>();

            foreach (var expediaDataTransferObject in expediaDataTransferObjects)
            {
                if (!regionExpediaIdsToIds.TryGetValue(expediaDataTransferObject.RegionID, out var regionId) ||
                    !propertyIdsToIds.TryGetValue(expediaDataTransferObject.EANHotelID, out var propertyId)) continue;

                var propertyToRegion = new PropertyToRegion { Id = propertyId, ToId = regionId, CreatorId = creatorId };

                propertyToRegions.Enqueue(propertyToRegion);
            }

            return propertyToRegions.ToArray();
        }
    }
}