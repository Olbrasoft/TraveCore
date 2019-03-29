using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Geography;
using Olbrasoft.Travel.Data.Repositories.Localization;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography;
using System.Collections.Generic;
using System.Linq;


namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class RegionsImporter : Importer
    {
        private readonly IParserFactory _parserFactory;
        protected IParser<ParentRegion> Parser;
        protected Queue<ParentRegion> ParentRegions = new Queue<ParentRegion>();

        public RegionsImporter(IProvider provider, IParserFactory parserFactory, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
            _parserFactory = parserFactory;
        }

        protected override void RowLoaded(string[] items)
        {
            ParentRegions.Enqueue(Parser.Parse(items));
        }

        public override void Import(string path)
        {
            Parser = _parserFactory.Create<ParentRegion>(Provider.GetFirstLine(path));

            LoadData(path);

            var parentRegions = ParentRegions.ToArray();

            const int batchSize = 300000;

            var expediaRegionIdsToIds = ImportRegions(parentRegions, RepositoryFactory.TypesOfRegions().DescriptionsToIds, RepositoryFactory.Regions(), batchSize, CreatorId,
                out var subClassNames);

            var subClasses = ImportSubClasses(RepositoryFactory.Names<Subclass>(), subClassNames, CreatorId);

            ImportRegionsToSubclasses(parentRegions, RepositoryFactory.ManyToMany<RegionToSubclass>(), batchSize,
                expediaRegionIdsToIds, subClasses, CreatorId);

            ImportLocalized(parentRegions, RepositoryFactory.Localized<RegionTranslation>(), batchSize, expediaRegionIdsToIds, DefaultLanguageId, CreatorId);

            ImportRegionsToRegions(parentRegions, RepositoryFactory.ManyToMany<RegionToRegion>(), batchSize, expediaRegionIdsToIds, CreatorId);

            ParentRegions = null;
        }

        private void ImportRegionsToRegions(IEnumerable<ParentRegion> parentRegions,
            IManyToManyRepository<RegionToRegion> repository, 
            int batchSize,
            IReadOnlyDictionary<long, int> eanRegionIdsToIds,
            int creatorId)
        {
            LogBuild<RegionToRegion>();
            var regionsToRegions = BuildRegionsToRegions(
                parentRegions,
                eanRegionIdsToIds,
                creatorId
            );

            var count = regionsToRegions.Length;

            LogAssembled(count);

            if (count <= 0) return;
            LogSave<RegionToRegion>();
            repository.BulkSave(regionsToRegions, batchSize);
            LogSaved<RegionToRegion>();
        }

        private static RegionToRegion[] BuildRegionsToRegions(IEnumerable<ParentRegion> parentRegions,
            IReadOnlyDictionary<long, int> eanRegionIdsToIds,
            int creatorId)
        {
            var regionsToRegions = new HashSet<RegionToRegion>();
            foreach (var parentRegion in parentRegions)
            {
                if (!eanRegionIdsToIds.TryGetValue(parentRegion.ParentRegionID, out var parentRegionId)
                    ||
                    !eanRegionIdsToIds.TryGetValue(parentRegion.RegionID, out var regionId)
                )
                {
                    //throw new Exception(parentRegion.RegionID.ToString() + "," + parentRegion.ParentRegionID.ToString());
                    continue;
                }

                var regionToRegion = new RegionToRegion
                {
                    Id = regionId,
                    ToId = parentRegionId,
                    CreatorId = creatorId
                };

                if (!regionsToRegions.Contains(regionToRegion))
                {
                    regionsToRegions.Add(regionToRegion);
                }
            }

            return regionsToRegions.ToArray();
        }

        private void ImportLocalized<T>(
            IEnumerable<ParentRegion> parentRegions,
            ILocalizedRepository<T> repository,
            int batchSize,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int languageId,
            int creatorId

        ) where T : RegionTranslation, new()
        {
            LogBuild<T>();
            var localizedEntities = BuildLocalizedRegions<T>(parentRegions, expediaIdsToIds, languageId, creatorId);
            var count = localizedEntities.Length;
            LogAssembled(count);

            if (count <= 0) return;

            LogSave<T>();
            repository.BulkSave(localizedEntities, batchSize);
            LogSaved<T>();
        }

        private static T[] BuildLocalizedRegions<T>(
            IEnumerable<ParentRegion> parentRegions,
            IReadOnlyDictionary<long, int> eanRegionIdsToIds,
            int languageId,
            int creatorId
            )
            where T : RegionTranslation, new()
        {
            var localizedRegions = new Dictionary<int, T>();
            foreach (var parentRegion in parentRegions)
            {
                T localizedRegion;
                if (eanRegionIdsToIds.TryGetValue(parentRegion.ParentRegionID, out var regionId))
                {
                    if (!localizedRegions.ContainsKey(regionId))
                    {
                        localizedRegion = new T
                        {
                            Id = regionId,
                            Name = parentRegion.ParentRegionName,
                            CreatorId = creatorId,
                            LanguageId = languageId
                        };

                        if (parentRegion.ParentRegionName.Trim() != parentRegion.ParentRegionNameLong.Trim())
                        {
                            localizedRegion.LongName = parentRegion.ParentRegionNameLong;
                        }

                        localizedRegions.Add(regionId, localizedRegion);
                    }
                }

                if (!eanRegionIdsToIds.TryGetValue(parentRegion.RegionID, out regionId)) continue;
                if (localizedRegions.ContainsKey(regionId)) continue;
                localizedRegion = new T
                {
                    Id = regionId,
                    Name = parentRegion.RegionName,
                    CreatorId = creatorId,
                    LanguageId = languageId
                };

                if (parentRegion.RegionName.Trim() != parentRegion.RegionNameLong.Trim())
                {
                    localizedRegion.LongName = parentRegion.RegionNameLong;
                }

                localizedRegions.Add(regionId, localizedRegion);
            }

            return localizedRegions.Values.ToArray();
        }

        private void ImportRegionsToSubclasses(IEnumerable<ParentRegion> parentRegions,
            IManyToManyRepository<RegionToSubclass> repository,
            int batchSize,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            IReadOnlyDictionary<string, int> namesToSubClassIds,
            int creatorId)
        {
            LogBuild<RegionToSubclass>();
            var regionsToSubclasses =
                BuildRegionsToSubclasses(parentRegions, expediaIdsToIds, namesToSubClassIds, creatorId);
            var count = regionsToSubclasses.Length;
            LogAssembled(count);

            LogSave<RegionToSubclass>();
            repository.BulkSave(regionsToSubclasses, batchSize);
            LogSaved<RegionToSubclass>();
        }

        private static RegionToSubclass[] BuildRegionsToSubclasses(IEnumerable<ParentRegion> parentRegions,
          IReadOnlyDictionary<long, int> expediaIdsToIds,
          IReadOnlyDictionary<string, int> namesToSubClassIds,
          int creatorId
      )
        {
            var regionIds = new HashSet<long>();
            var regionsToTypes = new Queue<RegionToSubclass>();

            foreach (var parentRegion in parentRegions)
            {
                var subClassName = GetSubClassName(parentRegion.SubClass);

                if (regionIds.Contains(parentRegion.RegionID) ||
                    !expediaIdsToIds.TryGetValue(parentRegion.RegionID, out var id) ||
                    string.IsNullOrEmpty(subClassName) ||
                    !namesToSubClassIds.TryGetValue(parentRegion.SubClass, out var subClassId)) continue;

                var regionToType = new RegionToSubclass
                {
                    Id = id,
                    ToId = subClassId,
                    CreatorId = creatorId
                };

                regionsToTypes.Enqueue(regionToType);
                regionIds.Add(parentRegion.RegionID);
            }

            return regionsToTypes.ToArray();
        }

        private IReadOnlyDictionary<string, int> ImportSubClasses(INamesRepository<Subclass> repository, IEnumerable<string> subClassesNames, int creatorId)
        {
            LogBuild<Subclass>();
            var subClasses = subClassesNames.Select(s => new Subclass { Name = s, CreatorId = creatorId }).ToArray();
            var count = subClasses.Length;
            LogAssembled(count);

            if (count <= 0) return repository.NamesToIds;
            LogSave<Subclass>();
            repository.BulkSave(subClasses);
            LogSaved<Subclass>();

            return repository.NamesToIds;
        }

        private IReadOnlyDictionary<long, int> ImportRegions(ParentRegion[] parentRegions,
            IReadOnlyDictionary<string, int> descriptionsToTypeIds,
            IRegionsRepository repository,
            int batchSize,
            int creatorId,
            out HashSet<string> subClassNames
        )
        {
            ImportParentRegions(parentRegions, descriptionsToTypeIds, repository, batchSize, creatorId);

            LogBuild<Region>();

            var regions = BuildRegions(parentRegions, descriptionsToTypeIds, creatorId, out subClassNames);
            var count = regions.Length;
            LogAssembled(count);

            if (count <= 0) return repository.ExpediaIdsToIds;

            LogSave<Region>();
            repository.BulkSave(regions, batchSize, p => p.Coordinates, p => p.CenterCoordinates);
            LogSaved<Region>();

            return repository.ExpediaIdsToIds;
        }

        private void ImportParentRegions(IEnumerable<ParentRegion> parentRegions,
            IReadOnlyDictionary<string, int> descriptionsToTypeIds,
            IRegionsRepository repository,
            int batchSize,
            int creatorId
        )
        {
            WriteLog("ParentRegions Build.");
            var regions = BuildParentRegions(parentRegions, descriptionsToTypeIds, creatorId);

            var count = regions.Length;
            WriteLog($"ParentRegions Assembled:{count} Regions.");

            if (count <= 0) return;
            WriteLog("ParentRegions Save.");
            repository.BulkSave(regions, batchSize, p => p.Coordinates, p => p.CenterCoordinates);
            WriteLog("ParenRegions Saved.");
        }

        private static Region[] BuildRegions(IEnumerable<ParentRegion> parentRegions,
            IReadOnlyDictionary<string, int> descriptionsToTypeIds,
            int creatorId,
            out HashSet<string> subClassesNames
        )
        {
            subClassesNames = new HashSet<string>();
            var regions = new Dictionary<long, Region>();

            foreach (var parentRegion in parentRegions)
            {
                if (regions.ContainsKey(parentRegion.RegionID) || !descriptionsToTypeIds.TryGetValue(parentRegion.RegionType, out var subTypeId)) continue;

                var region = new Region
                {
                    SubtypeId = subTypeId,
                    ExpediaId = parentRegion.RegionID,
                    CreatorId = creatorId
                };

                var subClassName = GetSubClassName(parentRegion.SubClass);

                if (!string.IsNullOrEmpty(subClassName) && !subClassesNames.Contains(subClassName))
                {
                    subClassesNames.Add(subClassName);
                }

                regions.Add(parentRegion.RegionID, region);
            }
            return regions.Values.ToArray();
        }

        private static Region[] BuildParentRegions(IEnumerable<ParentRegion> parentRegions,
            IReadOnlyDictionary<string, int> descriptionsToTypeIds,
            int creatorId
        )
        {
            var regions = new Dictionary<long, Region>();
            foreach (var parentRegion in parentRegions)
            {
                if (regions.ContainsKey(parentRegion.ParentRegionID) || !descriptionsToTypeIds.TryGetValue(parentRegion.ParentRegionType, out var subTypeId)) continue;

                var region = new Region
                {
                    SubtypeId = subTypeId,
                    ExpediaId = parentRegion.ParentRegionID,
                    CreatorId = creatorId
                };

                regions.Add(parentRegion.ParentRegionID, region);
            }
            return regions.Values.ToArray();
        }
    }
}