using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;


namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class RegionsTypesOfCitiesAndNeighborhoodsImporter : Importer
    {
        protected int SubtypeId;
        protected int SubclassId;

        protected Queue<Region> Regions = new Queue<Region>();

        protected IDictionary<long, Tuple<string, string>> AdeptsToLocalizedRegions = new Dictionary<long, Tuple<string, string>>();

        public RegionsTypesOfCitiesAndNeighborhoodsImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!long.TryParse(items[0], out var eanRegionId)) return;

            AdeptsToLocalizedRegions.Add(eanRegionId, new Tuple<string, string>(items[1], null));

            var region = new Region
            {
                SubtypeId = SubtypeId,
                ExpediaId = eanRegionId,
                Coordinates = CreatePolygon(items[2]),
                CreatorId = CreatorId
            };

            region.Coordinates.SRID = 4326;

            Regions.Enqueue(region);
        }

        public override void Import(string path)
        {
            LogBuild<Region>();

            LoadData(path);

            var expediaIdsToIds = SaveRegionsAndReturnExpediaIdsToIds(Regions.ToArray(), RepositoryFactory.Regions(), 90000, p => p.CenterCoordinates);

            Regions = null;

            ImportLocalizedRegions(AdeptsToLocalizedRegions, RepositoryFactory.Localized<RegionTranslation>(), expediaIdsToIds, DefaultLanguageId, CreatorId);

            var regionsExpediaIds = AdeptsToLocalizedRegions.Keys;

            AdeptsToLocalizedRegions = null;
            
            ImportRegionsToSubclass(RepositoryFactory.ManyToMany<RegionToSubclass>(), regionsExpediaIds, expediaIdsToIds, SubclassId, CreatorId);
        }

        private void ImportRegionsToSubclass(
            IManyToManyRepository<RegionToSubclass>repository,
            ICollection<long> regionsExpediaIds,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int subclassId,
            int creatorId
            )
        {
            LogBuild<RegionToSubclass>();
            var regionsToSubclasses = BuildRegionsToSubclasses(regionsExpediaIds, expediaIdsToIds, subclassId, creatorId);
            var count = regionsToSubclasses.Length;
            LogAssembled(count);

            if (count <= 0) return;

            LogSave<RegionToSubclass>();
            repository.BulkSave(regionsToSubclasses, count);
            LogSaved<RegionToSubclass>();
        }

        protected RegionToSubclass[] BuildRegionsToSubclasses(
            ICollection<long> regionsExpediaIds,
            IReadOnlyDictionary<long, int> expediaIdsToIds,
            int subClassId,
            int creatorId
        )
        {
            var regionsToSubclasses = new Queue<RegionToSubclass>();

            foreach (var regionExpediaId in regionsExpediaIds)
            {
                if (!expediaIdsToIds.TryGetValue(regionExpediaId, out var id)) continue;
                var regionToSubclass = new RegionToSubclass
                {
                    Id = id,
                    ToId = subClassId,
                  //  SubclassId = subclassId,
                    CreatorId = creatorId
                };

                regionsToSubclasses.Enqueue(regionToSubclass);
            }

            return regionsToSubclasses.ToArray();
        }

        public IPolygon CreatePolygon(string s)
        {
            var spl = s.Split(':');
            var coordinates = new Queue<Coordinate>();
            Coordinate closedPoint = null;

            //var pointsString = new StringBuilder();
          
            foreach (var s1 in spl)
            {
                var latLon = s1.Split(';');

               // pointsString.Append($"{latLon[0]},{latLon[1]}");
                var coordinate = new Coordinate (double.Parse(latLon[1], CultureInfo.InvariantCulture), double.Parse(latLon[0], CultureInfo.InvariantCulture));
                if (closedPoint == null) closedPoint = coordinate;
                    
               coordinates.Enqueue(coordinate);
            }

            coordinates.Enqueue(closedPoint);
            // pointsString.Append(pointsString.ToString().Split(',').First());

            var polygon = new Polygon(new LinearRing(coordinates.ToArray()));
            polygon.Normalize();
            
            return polygon;
        }
    }
}