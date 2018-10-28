using System;
using System.Collections.Generic;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository;
using Olbrasoft.Travel.Data.Repository.Geography;
using Olbrasoft.Travel.Data.Repository.Globalization;
using Country = Olbrasoft.Travel.Expedia.Affiliate.Network.Data.Transfer.Object.Geography.Country;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal class CountriesImporter : Importer
    {
        public class CandidateCountry
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }

        private static IEnumerable<CandidateCountry> ProbablyMissingCountries => new[]
        {
            new CandidateCountry
            {
                Name = "Yemen",
                Code = "YE"
            },

            new CandidateCountry()
            {
                Name = "Somalia",
                Code = "SO"
            },
            new CandidateCountry()
            {

                // ReSharper disable once StringLiteralTypo
                Name = "Timor-Leste",
                Code = "TL"
            },
        };

        private readonly IParserFactory _parserFactory;
        protected IParser<Country> Parser;
        protected Queue<Country> EanCountries = new Queue<Country>();

        public CountriesImporter(IProvider provider, IParserFactory parserFactory, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, factoryOfRepositories, sharedProperties, logger)
        {
            _parserFactory = parserFactory;
        }

        protected override void RowLoaded(string[] items)
        {
            EanCountries.Enqueue(Parser.Parse(items));
        }

        public override void Import(string path)
        {
            Parser = _parserFactory.Create<Country>(Provider.GetFirstLine(path));

            LoadData(path);

            var eanCountries = EanCountries.ToArray();
            EanCountries = null;

            var regionsRepository = FactoryOfRepositories.Regions();
            var regionsEanIdsToIds = regionsRepository.EanIdsToIds;

            regionsEanIdsToIds = ImportRegions(eanCountries, regionsRepository, regionsEanIdsToIds);

            ImportLocalizedRegions(eanCountries, FactoryOfRepositories.OfLocalized<LocalizedRegion>(), regionsEanIdsToIds);

            var typeOfRegionCountryId = FactoryOfRepositories.GeographyNamesRepository<TypeOfRegion>().GetId("Country");

            ImportRegionsToTypes(eanCountries, FactoryOfRepositories.RegionsToTypes(), regionsEanIdsToIds, typeOfRegionCountryId);

            ImportRegionsToRegions(eanCountries, FactoryOfRepositories.GeographyManyToMany<RegionToRegion>(), regionsEanIdsToIds);

            var countriesRepository = FactoryOfRepositories.AdditionalRegionsInfo<Travel.Data.Entity.Geography.Country>();

            ImportCountries(eanCountries, countriesRepository, regionsEanIdsToIds);

            ImportProbablyMissingCountries(ProbablyMissingCountries, countriesRepository, typeOfRegionCountryId, regionsRepository);
        }

        private void ImportProbablyMissingCountries(IEnumerable<CandidateCountry> probablyMissingCountries,
            IAdditionalRegionsInfoRepository<Travel.Data.Entity.Geography.Country> countriesRepository, int typeOfRegionCountryId,
            IRegionsRepository regionsRepository)
        {
            foreach (var probablyMissingCountry in probablyMissingCountries)
            {
                if (countriesRepository.Exists(c => c.Code == probablyMissingCountry.Code)) continue;

                var region = new Region
                {
                    CreatorId = CreatorId,DateAndTimeOfCreation = DateTime.Now,
                    Coordinates = Geometry.DefaultFactory.CreatePolygon(new Coordinate[]
                    {
                        new Coordinate(-122.358, 47.653), new Coordinate(-122.348, 47.649), new Coordinate(-122.358, 47.658), new Coordinate(-122.358 ,47.653)
                    }),
                    CenterCoordinates = Point.Empty
                    
                };

                region.Coordinates.SRID = 4326;
                region.CenterCoordinates.SRID = 4326;

                region.LocalizedRegions.Add(new LocalizedRegion
                {
                    LanguageId = DefaultLanguageId,
                    Name = probablyMissingCountry.Name,
                    CreatorId = CreatorId
                });

                region.RegionsToTypes.Add(new RegionToType
                {
                    ToId = typeOfRegionCountryId,
                    CreatorId = CreatorId
                });

                var country = new Travel.Data.Entity.Geography.Country
                {
                    Code = probablyMissingCountry.Code,
                    CreatorId = CreatorId
                };

                region.AdditionalCountryProperties = country;

                regionsRepository.Add(region);

            }
        }

        private void ImportCountries(Country[] eanCountries,
            IAdditionalRegionsInfoRepository<Travel.Data.Entity.Geography.Country> repository,
            IReadOnlyDictionary<long, int> regionsEanIdsToIds
           )
        {
            LogBuild<Travel.Data.Entity.Geography.Country>();
            var countries = BuildCountries(eanCountries, regionsEanIdsToIds, CreatorId);
            var count = countries.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<Travel.Data.Entity.Geography.Country>();
            repository.BulkSave(countries);
            LogSaved<Travel.Data.Entity.Geography.Country>();
        }

        private void ImportRegionsToRegions(
            IEnumerable<Country> eanCountries,
            IManyToManyRepository<RegionToRegion> repository,
            IReadOnlyDictionary<long, int> regionsEanIdsToIds)
        {
            Logger.Log("Build RegionsToRegions from CountryList");
            var regionsToRegions = BuildRegionsToRegions(eanCountries, regionsEanIdsToIds, CreatorId);
            var count = regionsToRegions.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<RegionToRegion>();
            repository.BulkSave(regionsToRegions, count);
            LogSaved<RegionToRegion>();
        }

        private void ImportRegionsToTypes(
            Country[] eanCountries,
            IRegionsToTypesRepository repository,
            IReadOnlyDictionary<long, int> regionsEanIdsToIds,
            int typeOfRegionCountryId
            )
        {
            if (eanCountries == null) throw new ArgumentNullException(nameof(eanCountries));
            LogBuild<RegionToType>();
            var regionsToTypes = BuildRegionsToTypes(eanCountries, regionsEanIdsToIds, typeOfRegionCountryId, CreatorId);
            var count = regionsToTypes.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<RegionToType>();
            repository.BulkSave(regionsToTypes);
            LogSaved<RegionToType>();
        }

        private void ImportLocalizedRegions(Country[] eanCountries, IOfLocalized<LocalizedRegion> repository, IReadOnlyDictionary<long, int> regionsEanIdsToIds)
        {
            Logger.Log("Build localizedRegions from CountryList");
            var localizedRegions = BuildLocalizedRegions(eanCountries, regionsEanIdsToIds, DefaultLanguageId, CreatorId);
            var count = localizedRegions.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<LocalizedRegion>();
            repository.BulkSave(localizedRegions, count);
            LogSaved<LocalizedRegion>();
        }

        private IReadOnlyDictionary<long, int> ImportRegions(
            IEnumerable<Country> eanCountries,
            IRegionsRepository regionsRepository,
            IReadOnlyDictionary<long, int> eanIdsToIds
            )
        {
            Logger.Log("Build Regions from CountryList");
            var regions = BuildRegions(eanCountries, eanIdsToIds, CreatorId);
            var count = regions.Length;
            Logger.Log($"Assembled {count} Regions from CountryList.");

            if (count <= 0) return eanIdsToIds;

            LogSave<Region>();
            regionsRepository.BulkSave(regions);
            LogSaved<Region>();

            eanIdsToIds = regionsRepository.EanIdsToIds;

            return eanIdsToIds;
        }

        private static RegionToRegion[] BuildRegionsToRegions(
            IEnumerable<Country> eanCountries,
            IReadOnlyDictionary<long, int> eanIdsToIds,
            int creatorId
        )
        {
            var regionsToRegions = new Queue<RegionToRegion>();
            foreach (var eanCountry in eanCountries)
            {
                if (!eanIdsToIds.TryGetValue(eanCountry.CountryID, out var id) || !eanIdsToIds.TryGetValue(eanCountry.ContinentID, out var toId)) continue;

                var regionToRegion = new RegionToRegion()
                {
                    Id = id,
                    ToId = toId,
                    CreatorId = creatorId
                };

                regionsToRegions.Enqueue(regionToRegion);
            }

            return regionsToRegions.ToArray();
        }

        public Travel.Data.Entity.Geography.Country[] BuildCountries(Country[] eanCountries,
            IReadOnlyDictionary<long, int> eanIdsToIds,
            int creatorId)
        {
            var countries = new Queue<Travel.Data.Entity.Geography.Country>();

            foreach (var eanCountry in eanCountries)
            {
                if (!eanIdsToIds.TryGetValue(eanCountry.CountryID, out var id)) continue;
                var country = new Travel.Data.Entity.Geography.Country
                {
                    Id = id,
                    Code = eanCountry.CountryCode,
                    CreatorId = creatorId
                };
                countries.Enqueue(country);
            }

            return countries.ToArray();
        }

        private static RegionToType[] BuildRegionsToTypes(IEnumerable<Country> eanCountries,
            IReadOnlyDictionary<long, int> eanIdsToIds,
            int typeOfRegionCountryId,
            int creatorId
        )
        {
            var regionsToTypes = new Queue<RegionToType>();

            foreach (var eanCountry in eanCountries)
            {
                if (!eanIdsToIds.TryGetValue(eanCountry.CountryID, out var id)) continue;

                var regionToType = new RegionToType
                {
                    Id = id,
                    ToId = typeOfRegionCountryId,
                    CreatorId = creatorId
                };

                regionsToTypes.Enqueue(regionToType);
            }

            return regionsToTypes.ToArray();
        }

        private static LocalizedRegion[] BuildLocalizedRegions(
            IEnumerable<Country> eanCountries,
            IReadOnlyDictionary<long, int> eanIdsToIds,
            int languageId,
            int creatorId)
        {
            var localizedRegions = new Queue<LocalizedRegion>();
            foreach (var eanCountry in eanCountries)
            {
                if (!eanIdsToIds.TryGetValue(eanCountry.CountryID, out var id)) continue;

                var localizedRegion = new LocalizedRegion
                {
                    Id = id,
                    LanguageId = languageId,
                    Name = eanCountry.CountryName,
                    CreatorId = creatorId
                };

                localizedRegions.Enqueue(localizedRegion);
            }

            return localizedRegions.ToArray();
        }

        private static Region[] BuildRegions(
            IEnumerable<Country> eanCountries,
            IReadOnlyDictionary<long, int> eanIdsToIds,
            int creatorId
        )
        {
            var regions = new Queue<Region>();
            foreach (var eanCountry in eanCountries)
            {
                if (eanIdsToIds.ContainsKey(eanCountry.CountryID)) continue;

                var region = new Region
                {
                    EanId = eanCountry.CountryID,
                    CreatorId = creatorId
                };

                regions.Enqueue(region);
            }

            return regions.ToArray();
        }
    }
}