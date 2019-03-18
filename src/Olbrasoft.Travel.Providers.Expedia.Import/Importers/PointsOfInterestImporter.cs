using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using RegionToSubclass = Olbrasoft.Travel.Data.Geography.RegionToSubclass;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class PointsOfInterestImporter : Importer
    {
        private int _subtypeId;

        protected int SubtypeId
        {
            get
            {
                if (_subtypeId == 0)
                {
                    _subtypeId = RepositoryFactory.Names<Subtype>().GetId("PointOfInterest");
                }

                return _subtypeId;
            }

            set => _subtypeId = value;
        }

        private IReadOnlyDictionary<string, int> _subclassesNamesToIds;

        protected IReadOnlyDictionary<string, int> SubClassesNamesToIds
        {
            get => _subclassesNamesToIds ??
                   (_subclassesNamesToIds = RepositoryFactory.Names<Subclass>().NamesToIds);

            set => _subclassesNamesToIds = value;
        }

        protected Queue<Region> Regions = new Queue<Region>();
        protected IDictionary<long, Tuple<string, string>> AdeptsToLocalizedRegions = new Dictionary<long, Tuple<string, string>>();
        protected IDictionary<long, int> RegionsExpediaIdsToSubClassIds = new Dictionary<long, int>();

        public PointsOfInterestImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!long.TryParse(items[0], out var expediaRegionId) ||
               !double.TryParse(items[3], NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out var latitude) ||
                !double.TryParse(items[4], NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out var longitude)) return;

            AdeptsToLocalizedRegions.Add(expediaRegionId, new Tuple<string, string>(items[1], items[2]));

            var region = new Region
            {
                SubtypeId = SubtypeId,
                ExpediaId = expediaRegionId,
                CenterCoordinates = CreatePoint(latitude, longitude),
                CreatorId = CreatorId
            };

            region.CenterCoordinates.SRID = 4326;

            Regions.Enqueue(region);

            var subClassName = GetSubClassName(items[5]);

            if (string.IsNullOrEmpty(subClassName) || !SubClassesNamesToIds.TryGetValue(subClassName, out var subClassId)) return;

            RegionsExpediaIdsToSubClassIds.Add(expediaRegionId, subClassId);
        }

        public override void Import(string path)
        {
            LogBuild<Region>();

            LoadData(path);

            SubClassesNamesToIds = null;

            var regionExpediaIdsToRegionIds = SaveRegionsAndReturnExpediaIdsToIds(Regions.ToArray(), RepositoryFactory.Regions(), 100000, p => p.Coordinates);

            Regions = null;

            ImportLocalizedRegions(AdeptsToLocalizedRegions, RepositoryFactory.Localized<LocalizedRegion>(), regionExpediaIdsToRegionIds, DefaultLanguageId, CreatorId);

            // var regionsExpediaIds = AdeptsToLocalizedRegions.Keys;
            //AdeptsToLocalizedRegions = null;

            ImportRegionsToSubclasses(RegionsExpediaIdsToSubClassIds, RepositoryFactory.ManyToMany<RegionToSubclass>(), regionExpediaIdsToRegionIds, CreatorId);
        }

        private void ImportRegionsToSubclasses(
            IDictionary<long, int> regionsExpediaIdsToSubClassIds,
            IManyToManyRepository<RegionToSubclass> repository,
            IReadOnlyDictionary<long, int> regionsExpediaIdsToRegionIds,
            int creatorId
            )
        {
            LogBuild<RegionToSubclass>();
            var regionsToSubclasses = BuildRegionsToSubclasses(regionsExpediaIdsToSubClassIds, regionsExpediaIdsToRegionIds, creatorId);
            var count = regionsToSubclasses.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<RegionToSubclass>();
            repository.BulkSave(regionsToSubclasses, count);
            LogSaved<RegionToSubclass>();
        }

        private static RegionToSubclass[] BuildRegionsToSubclasses(
            IDictionary<long, int> regionsExpediaIdsToSubClassIds,
            IReadOnlyDictionary<long, int> regionsExpediaIdsToRegionIds,
            int creatorId
            )
        {
            var regionsToTypes = new Queue<RegionToSubclass>();

            foreach (var regionExpediaId in regionsExpediaIdsToSubClassIds.Keys)
            {
                if (!regionsExpediaIdsToRegionIds.TryGetValue(regionExpediaId, out var id) ||
                    !regionsExpediaIdsToSubClassIds.TryGetValue(regionExpediaId, out var subClassId)) continue;

                var regionToType = new RegionToSubclass
                {
                    Id = id,
                    ToId = subClassId,
                    CreatorId = creatorId
                };

                regionsToTypes.Enqueue(regionToType);
            }

            return regionsToTypes.ToArray();
        }
    }
}