using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Geography;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories.Localization;


namespace Olbrasoft.Travel.Providers.Expedia.Import
{
    internal abstract class Importer<T> : Importer where T : class, new()
    {
        protected readonly object LockMe = new object();
        private readonly IParserFactory _parserFactory;
        protected IParser<T> Parser;
        protected Queue<T> ExpediaDataTransferObjects = new Queue<T>();

        protected Importer(IProvider provider, IParserFactory parserFactory, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
            _parserFactory = parserFactory;
        }

        protected override void RowLoaded(string[] items)
        {
            ExpediaDataTransferObjects.Enqueue(Parser.Parse(items));
        }

        protected override void LoadData(string path)
        {
            Parser = _parserFactory.Create<T>(Provider.GetFirstLine(path));
            base.LoadData(path);
        }

        protected void ImportLocalizedRegions(
            IEnumerable<IHaveRegionIdRegionName> eanDataTransferObjects,
            ILocalizedRepository<LocalizedRegion> repository,
            IReadOnlyDictionary<long, int> ExpediaIdsToIds,
            int languageId,
            int creatorId

        )
        {
            LogBuild<LocalizedRegion>();
            var localizedRegions = BuildLocalizedRegions(eanDataTransferObjects, ExpediaIdsToIds, languageId, creatorId);
            var count = localizedRegions.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<LocalizedRegion>();
            repository.BulkSave(localizedRegions, count);
            LogSaved<LocalizedRegion>();
        }

        protected void ImportLocalizedAccommodations(
            IEnumerable<IToLocalizedAccommodation> eanDataTransferObjects,
            ILocalizedRepository<LocalizedRealEstate> repository,
            IReadOnlyDictionary<int, int> accommodationsExpediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            LogBuild<LocalizedRealEstate>();
            var localizedAccommodations = BuildLocalizedAccommodations(eanDataTransferObjects,
                accommodationsExpediaIdsToIds, languageId, creatorId);

            var count = localizedAccommodations.Length;

            LogAssembled(count);

            if (count <= 0) return;

            LogSave<LocalizedRealEstate>();
            repository.BulkSave(localizedAccommodations);
            LogSaved<LocalizedRealEstate>();
        }

        protected static LocalizedRealEstate[] BuildLocalizedAccommodations(
            IEnumerable<IToLocalizedAccommodation> eanEntities,
            IReadOnlyDictionary<int, int> ExpediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            var localizedAccommodations = new Queue<LocalizedRealEstate>();

            foreach (var activeProperty in eanEntities)
            {
                if (!ExpediaIdsToIds.TryGetValue(activeProperty.EANHotelID, out var id)) continue;

                var localizedAccommodation = new LocalizedRealEstate()
                {
                    Id = id,
                    LanguageId = languageId,
                    Name = activeProperty.Name,
                    Location = activeProperty.Location,
                    CheckInTime = activeProperty.CheckInTime,
                    CheckOutTime = activeProperty.CheckOutTime,
                    CreatorId = creatorId
                };

                localizedAccommodations.Enqueue(localizedAccommodation);
            }

            return localizedAccommodations.ToArray();
        }

        protected CultureInfo CultureInfo(string eanLanguageCode)
        {
            return new CultureInfo(eanLanguageCode.Replace("_", "-"));
        }

        protected string EanLanguageCode(string fileName)
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            return fileNameWithoutExtension?.Substring(fileNameWithoutExtension.Length - 5);
        }

        protected LocalizedRegion[] BuildLocalizedRegions(IEnumerable<IHaveRegionIdRegionName> eanEntities,
            IReadOnlyDictionary<long, int> ExpediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            var localizedRegions = new Queue<LocalizedRegion>();
            Parallel.ForEach(eanEntities, eanEntity =>
            {
                if (!ExpediaIdsToIds.TryGetValue(eanEntity.RegionID, out var id)) return;

                var localizedRegion = new LocalizedRegion()
                {
                    Id = id,
                    LanguageId = languageId,
                    CreatorId = creatorId,
                    Name = eanEntity.RegionName
                };

                lock (LockMe)
                {
                    localizedRegions.Enqueue(localizedRegion);
                }
            });

            return localizedRegions.ToArray();
        }

        protected Region[] BuildRegions(
            IEnumerable<IHaveRegionIdLatitudeLongitude> entities, 
            int regionSubtypeId,
            int creatorId
        )
        {
            var regions = new Queue<Region>();

            //foreach (var entity in entities)
            //{
            //    var region = new Region
            //    {
            //        ExpediaId = entity.RegionID,
            //        CenterCoordinates = CreatePoint(entity.Latitude, entity.Longitude),
            //        CreatorId = creatorId
            //    };

            //     regions.Enqueue(region);

            //}

            Parallel.ForEach(entities, entity =>
            {
                var region = new Region
                {
                    SubtypeId = regionSubtypeId,
                    ExpediaId = entity.RegionID,
                    CenterCoordinates = CreatePoint(entity.Latitude, entity.Longitude),
                    CreatorId = creatorId
                };

                region.CenterCoordinates.SRID = 4326;

                lock (LockMe)
                {
                    regions.Enqueue(region);
                }
            });

            return regions.ToArray();
        }

        protected RegionToSubclass[] BuildRegionsToSubclasses(IEnumerable<IHaveRegionId> expediaDataTransferObjects,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int subClassId,
            int creatorId
        )
        {
            var regionsToTypes = new Queue<RegionToSubclass>();
            Parallel.ForEach(expediaDataTransferObjects, eanEntity =>
            {
                if (!expediaIdsToIds.TryGetValue(eanEntity.RegionID, out var id)) return;

                var regionToType = new RegionToSubclass
                {
                    Id = id,
                    ToId = subClassId,
                    CreatorId = creatorId
                };

                lock (LockMe)
                {
                    regionsToTypes.Enqueue(regionToType);
                }
            });

            return regionsToTypes.ToArray();
        }
    }

    public abstract class Importer : IImporter
    {
        protected readonly IProvider Provider;
        protected readonly IRepositoryFactory RepositoryFactory;
        protected readonly int DefaultLanguageId;
        protected readonly int CreatorId;
        protected readonly ILoggingImports Logger;

        private int _numberOfRowsLoaded;

        protected Importer(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
        {
            Provider = provider;
            RepositoryFactory = repositoryFactory;
            Logger = logger;
            DefaultLanguageId = sharedProperties.DefaultLanguageId;
            CreatorId = sharedProperties.CreatorId;
        }

        protected void Provider_SplittingLine(object sender, string[] items)
        {
            _numberOfRowsLoaded++;
            RowLoaded(items);
        }

        protected abstract void RowLoaded(string[] items);

        protected virtual void LoadData(string path)
        {
            WriteLog("Load data from: " + path);
            Provider.SplittingLine += Provider_SplittingLine;
            Provider.ReadToEnd(path);
            Provider.SplittingLine -= Provider_SplittingLine;
            WriteLog(_numberOfRowsLoaded.ToString());
        }

        public abstract void Import(string path);

        protected IReadOnlyDictionary<long, int> SaveRegionsAndReturnExpediaIdsToIds(
            Region[] regions,
            IRegionsRepository repository,
            int batchSize,
            params Expression<Func<Region, object>>[] ignorePropertiesWhenUpdating
        )
        {
            if (regions.Length <= 0) return repository.ExpediaIdsToIds;
            LogSave<Region>();
            repository.BulkSave(regions, batchSize, ignorePropertiesWhenUpdating);
            LogSaved<Region>();

            return repository.ExpediaIdsToIds;
        }

        protected void ImportLocalizedRegions(IDictionary<long, Tuple<string, string>> adeptsToLocalizedRegions,
            ILocalizedRepository<LocalizedRegion> repository,
            IReadOnlyDictionary<long, int> ExpediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            LogBuild<LocalizedRegion>();
            var localizedRegions = BuildLocalizedRegions(adeptsToLocalizedRegions, ExpediaIdsToIds, languageId, creatorId);
            var count = localizedRegions.Length;
            LogAssembled(count);

            if (count <= 0) return;

            LogSave<LocalizedRegion>();
            repository.BulkSave(localizedRegions, count, lr => lr.LongName);
            LogSaved<LocalizedRegion>();
        }

        public string RemoveDots(string source)
        {
            return source.Replace(".", string.Empty);
        }

        protected LocalizedRegion[] BuildLocalizedRegions(
            IDictionary<long, Tuple<string, string>> adeptsToLocalizedRegions,
            IReadOnlyDictionary<long, int> ExpediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            var localizedRegions = new Queue<LocalizedRegion>();

            foreach (var adeptToLocalizedRegion in adeptsToLocalizedRegions)
            {
                if (!ExpediaIdsToIds.TryGetValue(adeptToLocalizedRegion.Key, out var id)) continue;

                var localizedRegion = new LocalizedRegion()
                {
                    Id = id,
                    LanguageId = languageId,
                    CreatorId = creatorId,
                    Name = adeptToLocalizedRegion.Value.Item1
                };

                if (!string.IsNullOrEmpty(adeptToLocalizedRegion.Value.Item2))
                {
                    localizedRegion.LongName = adeptToLocalizedRegion.Value.Item2;
                }

                localizedRegions.Enqueue(localizedRegion);
            }

            return localizedRegions.ToArray();
        }

        public static IPoint CreatePoint(double latitude, double longitude)
        {
            //var point = string.Format(CultureInfo.InvariantCulture.NumberFormat,
            //    "POINT({0} {1})", longitude, latitude);
            // 4326 is most common coordinate system used by GPS/Maps
            return new Point(new Coordinate(longitude, latitude,0));
            //DbGeography.PointFromText(point, 4326);
        }

        protected static string ParsePath(string url)
        {
            url = url.Replace("https://i.travelapi.com/hotels/", "").Replace(Path.GetFileName(url), "");
            return url.Remove(url.Length - 1);
        }

        protected static string RemovePostFix(string url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));

            url = Path.GetFileNameWithoutExtension(url);

            return url.Remove(url.Length - 2);
        }

        protected static string GetSubClassName(string name)
        {
            // ReSharper disable once StringLiteralTypo
            return string.IsNullOrEmpty(name) ? null : name.ToLower().Replace("musuems", "museums");
        }

        protected void WriteLog(object obj)
        {
            Logger?.Log(obj.ToString());
        }

        protected void LogAssembled(int count)
        {
            WriteLog(count);
        }

        protected void LogBuild<TL>()
        {
            WriteLog($"{typeof(TL)} Build.");
        }

        protected void LogSave<TL>()
        {
            WriteLog($"{typeof(TL)} Save.");
        }

        protected void LogSaved<TL>()
        {
            WriteLog($"{typeof(TL)} Saved.");
        }

        public virtual void Dispose()
        {
            Provider.SplittingLine -= Provider_SplittingLine;
            GC.SuppressFinalize(this);
        }
    }
}