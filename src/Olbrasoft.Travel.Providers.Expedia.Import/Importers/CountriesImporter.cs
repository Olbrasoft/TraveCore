using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Geography;
using Olbrasoft.Travel.Data.Repositories.Localization;
using System;
using System.Collections.Generic;
using Country = Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Geography.Country;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
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

        public CountriesImporter(IProvider provider, IParserFactory parserFactory, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
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

            var expediaCountries = EanCountries.ToArray();
            EanCountries = null;

            var regionsRepository = RepositoryFactory.Regions();
            var regionsExpediaIdsToIds = regionsRepository.ExpediaIdsToIds;

            var subtypeCountryId = RepositoryFactory.Names<Subtype>().GetId("Country");

            regionsExpediaIdsToIds = ImportRegions(expediaCountries, regionsRepository, regionsExpediaIdsToIds, subtypeCountryId);

            ImportLocalizedRegions(expediaCountries, RepositoryFactory.Localized<LocalizedRegion>(), regionsExpediaIdsToIds);

            //ImportRegionsToTypes(eanCountries, RepositoryFactory.ManyToMany<RegionToSubclass>(), regionsExpediaIdsToIds, subtypeCountryId);

            ImportRegionsToRegions(expediaCountries, RepositoryFactory.ManyToMany<RegionToRegion>(), regionsExpediaIdsToIds);

            var countriesRepository = RepositoryFactory.AdditionalRegionsInfo<Data.Geography.Country>();

            ImportCountries(expediaCountries, countriesRepository, regionsExpediaIdsToIds);

            ImportProbablyMissingCountries(ProbablyMissingCountries, countriesRepository, subtypeCountryId, regionsRepository);
        }

        private void ImportProbablyMissingCountries(IEnumerable<CandidateCountry> probablyMissingCountries,
            IAdditionalRegionsInfoRepository<Data.Geography.Country> countriesRepository, int subtypeCountryId,
            IRegionsRepository regionsRepository)
        {
            foreach (var probablyMissingCountry in probablyMissingCountries)
            {
                if (countriesRepository.Exists(c => c.Code == probablyMissingCountry.Code)) continue;

                var region = new Region
                {
                    CreatorId = CreatorId,
                    Created = DateTime.Now,
                    Coordinates = Geometry.DefaultFactory.CreatePolygon(new[]
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

                region.SubtypeId = subtypeCountryId;

                var country = new Data.Geography.Country
                {
                    Code = probablyMissingCountry.Code,
                    CreatorId = CreatorId
                };

                region.ExpandingInformationAboutCountry = country;

                regionsRepository.Add(region);
            }
        }

        private void ImportCountries(Country[] eanCountries,
            IAdditionalRegionsInfoRepository<Data.Geography.Country> repository,
            IReadOnlyDictionary<long, int> regionsExpediaIdsToIds
           )
        {
            LogBuild<Data.Geography.Country>();
            var countries = BuildCountries(eanCountries, regionsExpediaIdsToIds, CreatorId);
            var count = countries.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<Data.Geography.Country>();
            repository.BulkSave(countries);
            LogSaved<Data.Geography.Country>();
        }

        private void ImportRegionsToRegions(
            IEnumerable<Country> eanCountries,
            IManyToManyRepository<RegionToRegion> repository,
            IReadOnlyDictionary<long, int> regionsExpediaIdsToIds)
        {
            Logger.Log("Build RegionsToRegions from CountryList");
            var regionsToRegions = BuildRegionsToRegions(eanCountries, regionsExpediaIdsToIds, CreatorId);
            var count = regionsToRegions.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<RegionToRegion>();
            repository.BulkSave(regionsToRegions, count);
            LogSaved<RegionToRegion>();
        }

        //private void ImportRegionsToTypes(
        //    Country[] eanCountries,
        //    IManyToManyRepository<RegionToSubclass> repository,
        //    IReadOnlyDictionary<long, int> regionsExpediaIdsToIds,
        //    int subtypeCountryId
        //    )
        //{
        //    if (eanCountries == null) throw new ArgumentNullException(nameof(eanCountries));
        //    LogBuild<RegionToSubclass>();
        //    var regionsToTypes = BuildRegionsToSubclasses(eanCountries, regionsExpediaIdsToIds, subtypeCountryId, CreatorId);
        //    var count = regionsToTypes.Length;
        //    LogAssembled(count);

        //    if (count <= 0) return;
        //    LogSave<RegionToSubclass>();
        //    repository.BulkSave(regionsToTypes);
        //    LogSaved<RegionToSubclass>();
        //}

        private void ImportLocalizedRegions(Country[] eanCountries, ILocalizedRepository<LocalizedRegion> repository, IReadOnlyDictionary<long, int> regionsExpediaIdsToIds)
        {
            Logger.Log("Build localizedRegions from CountryList");
            var localizedRegions = BuildLocalizedRegions(eanCountries, regionsExpediaIdsToIds, DefaultLanguageId, CreatorId);
            var count = localizedRegions.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<LocalizedRegion>();
            repository.BulkSave(localizedRegions, count);
            LogSaved<LocalizedRegion>();
        }

        private IReadOnlyDictionary<long, int> ImportRegions(IEnumerable<Country> eanCountries,
            IRegionsRepository regionsRepository,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int subtypeCountryId)
        {
            Logger.Log("Build Regions from CountryList");
            var regions = BuildRegions(eanCountries, expediaIdsToIds, subtypeCountryId, CreatorId);
            var count = regions.Length;
            Logger.Log($"Assembled {count} Regions from CountryList.");

            if (count <= 0) return expediaIdsToIds;

            LogSave<Region>();
            regionsRepository.BulkSave(regions);
            LogSaved<Region>();

            expediaIdsToIds = regionsRepository.ExpediaIdsToIds;

            return expediaIdsToIds;
        }

        private static RegionToRegion[] BuildRegionsToRegions(
            IEnumerable<Country> eanCountries,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int creatorId
        )
        {
            var regionsToRegions = new Queue<RegionToRegion>();
            foreach (var eanCountry in eanCountries)
            {
                if (!expediaIdsToIds.TryGetValue(eanCountry.CountryID, out var id) || !expediaIdsToIds.TryGetValue(eanCountry.ContinentID, out var toId)) continue;

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

        public Data.Geography.Country[] BuildCountries(Country[] eanCountries,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int creatorId)
        {
            var countries = new Queue<Data.Geography.Country>();

            foreach (var eanCountry in eanCountries)
            {
                if (!expediaIdsToIds.TryGetValue(eanCountry.CountryID, out var id)) continue;
                var country = new Data.Geography.Country
                {
                    Id = id,
                    Code = eanCountry.CountryCode,
                    CreatorId = creatorId
                };
                countries.Enqueue(country);
            }

            return countries.ToArray();
        }

        //private static RegionToSubclass[] BuildRegionsToSubclasses(IEnumerable<Country> eanCountries,
        //    IReadOnlyDictionary<long, int> ExpediaIdsToIds,
        //    int subtypeCountryId,
        //    int creatorId
        //)
        //{
        //    var regionsToTypes = new Queue<RegionToSubclass>();

        //    foreach (var eanCountry in eanCountries)
        //    {
        //        if (!ExpediaIdsToIds.TryGetValue(eanCountry.CountryID, out var id)) continue;

        //        var regionToType = new RegionToSubclass
        //        {
        //            Id = id,
        //            ToId = subtypeCountryId,
        //            CreatorId = creatorId
        //        };

        //        regionsToTypes.Enqueue(regionToType);
        //    }

        //    return regionsToTypes.ToArray();
        //}

        private static LocalizedRegion[] BuildLocalizedRegions(
            IEnumerable<Country> eanCountries,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int languageId,
            int creatorId)
        {
            var localizedRegions = new Queue<LocalizedRegion>();
            foreach (var eanCountry in eanCountries)
            {
                if (!expediaIdsToIds.TryGetValue(eanCountry.CountryID, out var id)) continue;

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
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int subtypeCountryId,
            int creatorId
        )
        {
            var regions = new Queue<Region>();
            foreach (var eanCountry in eanCountries)
            {
                if (expediaIdsToIds.ContainsKey(eanCountry.CountryID)) continue;

                var region = new Region
                {
                    ExpediaId = eanCountry.CountryID,
                    SubtypeId = subtypeCountryId,
                    CreatorId = creatorId
                };

                regions.Enqueue(region);
            }

            return regions.ToArray();
        }
    }
}