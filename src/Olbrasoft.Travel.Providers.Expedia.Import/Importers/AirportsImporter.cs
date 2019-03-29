using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Geography;
using Olbrasoft.Travel.Data.Repositories.Localization;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography;
using System.Collections.Generic;
using Country = Olbrasoft.Travel.Data.Geography.Country;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class AirportsImporter : Importer<AirportCoordinates>
    {
        public AirportsImporter(IProvider provider, IParserFactory parserFactory, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, parserFactory, repositoryFactory, sharedProperties, logger)
        {
        }

        public override void Import(string path)
        {
            LoadData(path);

            var airportsCoordinates = ExpediaDataTransferObjects.ToArray();
            ExpediaDataTransferObjects = null;

            var regionsExpediaIdsToIds =
                ImportRegions(airportsCoordinates, RepositoryFactory.Regions(), CreatorId);

            ImportLocalizedRegions(airportsCoordinates, RepositoryFactory.Localized<RegionTranslation>(), regionsExpediaIdsToIds, DefaultLanguageId, CreatorId);

            ImportAirports(airportsCoordinates, RepositoryFactory.AdditionalRegionsInfo<Airport>(), regionsExpediaIdsToIds, CreatorId);

            ImportRegionsToSubtypes(airportsCoordinates, RepositoryFactory.ManyToMany<RegionToSubclass>(),
                regionsExpediaIdsToIds, RepositoryFactory.Names<Subclass>().GetId("airport"));
            
            ImportRegionsToRegions(airportsCoordinates, RepositoryFactory.ManyToMany<RegionToRegion>(),
                regionsExpediaIdsToIds, RepositoryFactory.AdditionalRegionsInfo<Country>().CodesToIds,
                CreatorId);
        }

        private void ImportRegionsToRegions(
            IEnumerable<AirportCoordinates> airportsCoordinates,
            IManyToManyRepository<RegionToRegion> repository,
            IReadOnlyDictionary<long, int> regionsExpediaIdsToIds,
            IReadOnlyDictionary<string, int> eanCountryCodeToIds,
            int creatorId
        )
        {
            LogBuild<RegionToRegion>();
            var regionsToRegions = BuildRegionsToRegions(airportsCoordinates, regionsExpediaIdsToIds,
                eanCountryCodeToIds, creatorId);
            var count = regionsToRegions.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<RegionToRegion>();
            repository.BulkSave(regionsToRegions, count);
            LogSaved<RegionToRegion>();
        }

        private RegionToRegion[] BuildRegionsToRegions(IEnumerable<AirportCoordinates> eanAirportsCoordinates,
            IReadOnlyDictionary<long, int> eanRegionIdsToIds,
            IReadOnlyDictionary<string, int> eanCountryCodeToIds,
            int creatorId
        )
        {
            var regionToRegions = new Queue<RegionToRegion>();

            foreach (var eanAirport in eanAirportsCoordinates)
            {
                if (!eanRegionIdsToIds.TryGetValue(eanAirport.AirportID, out var id))
                {
                    WriteLog($"Not found AirportID {eanAirport.AirportID}");
                    continue;
                }

                if (eanAirport.MainCityID != null)
                {
                    var cityId = (long)eanAirport.MainCityID;

                    if (eanRegionIdsToIds.TryGetValue(cityId, out var toId))
                    {
                        var regionToRegion = new RegionToRegion
                        {
                            Id = id,
                            ToId = toId,
                            CreatorId = creatorId
                        };

                        regionToRegions.Enqueue(regionToRegion);
                    }
                    else
                    {
                        WriteLog($"Not found MainCityID {eanAirport.AirportID}");
                    }
                }

                if (!eanCountryCodeToIds.TryGetValue(eanAirport.CountryCode, out var toId1)) continue;
                {
                    var regionToRegion = new RegionToRegion
                    {
                        Id = id,
                        ToId = toId1,
                        CreatorId = creatorId
                    };

                    regionToRegions.Enqueue(regionToRegion);
                }
            }

            return regionToRegions.ToArray();
        }

        private void ImportRegionsToSubtypes(
            IEnumerable<AirportCoordinates> airportsCoordinates,
            IManyToManyRepository<RegionToSubclass> repository,
            IReadOnlyDictionary<long, int> expediaIdsToIds, int subClassAirportId)
        {
            LogBuild<RegionToSubclass>();
            var regionsToTypes =
                BuildRegionsToTypes(airportsCoordinates, expediaIdsToIds, subClassAirportId, CreatorId);
            var count = regionsToTypes.Length;
            LogAssembled(count);

            if (count <= 0) return;

            LogSave<RegionToSubclass>();
            repository.BulkSave(regionsToTypes);
            LogSaved<RegionToSubclass>();
        }

        private static RegionToSubclass[] BuildRegionsToTypes(IEnumerable<AirportCoordinates> eanAirportsCoordinates,
            IReadOnlyDictionary<long, int> expediaAirportIdsToIds,
            int subClassAirportId,
            int creatorId
        )
        {
            var regionsToTypes = new Queue<RegionToSubclass>();

            foreach (var entity in eanAirportsCoordinates)
            {
                if (!expediaAirportIdsToIds.TryGetValue(entity.AirportID, out var id)) continue;

                var regionToType = new RegionToSubclass
                {
                    Id = id,
                    ToId = subClassAirportId,
                    CreatorId = creatorId
                };

                regionsToTypes.Enqueue(regionToType);
            }
            return regionsToTypes.ToArray();
        }

        private void ImportAirports(
            IEnumerable<AirportCoordinates> airportsCoordinates,
            IAdditionalRegionsInfoRepository<Airport> repository,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int creatorId

        )
        {
            LogBuild<Airport>();
            var airports = BuildAirports(airportsCoordinates, expediaIdsToIds, creatorId);
            var count = airports.Length;
            LogAssembled(count);

            if (count <= 0) return;

            LogSave<Airport>();
            repository.BulkSave(airports, count);
            LogSaved<Airport>();
        }

        private static Airport[] BuildAirports(
            IEnumerable<AirportCoordinates> eanAirportsCoordinates,
            IReadOnlyDictionary<long, int> eanAirportIdsToIds,
            int creatorId
        )
        {
            var airports = new Queue<Airport>();

            foreach (var eanAirport in eanAirportsCoordinates)
            {
                if (!eanAirportIdsToIds.TryGetValue(eanAirport.AirportID, out var id)) continue;

                var airport = new Airport()
                {
                    Id = id,
                    Code = eanAirport.AirportCode,
                    CreatorId = creatorId
                };

                airports.Enqueue(airport);
            }

            return airports.ToArray();
        }

        private void ImportLocalizedRegions(
            IEnumerable<AirportCoordinates> airportsCoordinates,
            ITranslationsRepository<RegionTranslation> repository,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            LogBuild<RegionTranslation>();
            var localizedRegions = BuildLocalizedRegions(airportsCoordinates, expediaIdsToIds,
                languageId, creatorId);
            var count = localizedRegions.Length;
            LogAssembled(count);

            if (count <= 0) return;

            LogSave<RegionTranslation>();
            repository.BulkSave(localizedRegions, count);
            LogSaved<RegionTranslation>();
        }

        private static RegionTranslation[] BuildLocalizedRegions(
            IEnumerable<AirportCoordinates> airportsCoordinates,
            IReadOnlyDictionary<long, int> eanAirportIdsToIds,
            int languageId,
            int creatorId
        )
        {
            var localizedRegions = new Queue<RegionTranslation>();

            foreach (var eanAirport in airportsCoordinates)
            {
                if (!eanAirportIdsToIds.TryGetValue(eanAirport.AirportID, out var id)) continue;

                var localizedRegion = new RegionTranslation()
                {
                    Id = id,
                    LanguageId = languageId,
                    Name = eanAirport.AirportName,
                    CreatorId = creatorId
                };

                localizedRegions.Enqueue(localizedRegion);
            }

            return localizedRegions.ToArray();
        }

        private IReadOnlyDictionary<long, int> ImportRegions(
            IEnumerable<AirportCoordinates> airportsCoordinates,
            IRegionsRepository repository,
            int creatorId)
        {
            LogBuild<Region>();
            var regions = BuildRegions(airportsCoordinates, creatorId);
            var count = regions.Length;
            LogAssembled(count);

            if (count <= 0) return repository.ExpediaIdsToIds;

            LogSave<Region>();
            repository.BulkSave(regions, r => r.Coordinates, r => r.ExpediaId);
            LogSaved<Region>();

            return repository.ExpediaIdsToIds;
        }

        private static Region[] BuildRegions(IEnumerable<AirportCoordinates> eanAirportCoordinates,
            int creatorId
        )
        {
            var regions = new Queue<Region>();

            foreach (var eanAirport in eanAirportCoordinates)
            {
                var region = new Region
                {
                    CenterCoordinates = CreatePoint(eanAirport.Latitude, eanAirport.Longitude),
                    ExpediaId = eanAirport.AirportID,
                    CreatorId = creatorId
                };

                region.CenterCoordinates.SRID = 4326;

                regions.Enqueue(region);
            }

            return regions.ToArray();
        }
    }
}