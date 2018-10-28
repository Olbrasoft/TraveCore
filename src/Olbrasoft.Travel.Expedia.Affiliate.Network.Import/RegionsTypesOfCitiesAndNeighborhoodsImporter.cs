using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Repository;
using Olbrasoft.Travel.Data.Repository.Geography;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal class RegionsTypesOfCitiesAndNeighborhoodsImporter : Importer
    {
        protected int TypeOfRegionId;
        protected int SubClassId;

        protected Queue<Region> Regions = new Queue<Region>();

        protected IDictionary<long, Tuple<string, string>> AdeptsToLocalizedRegions = new Dictionary<long, Tuple<string, string>>();

        public RegionsTypesOfCitiesAndNeighborhoodsImporter(IProvider provider, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, factoryOfRepositories, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!long.TryParse(items[0], out var eanRegionId)) return;

            AdeptsToLocalizedRegions.Add(eanRegionId, new Tuple<string, string>(items[1], null));

            var region = new Region
            {
                EanId = eanRegionId,
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

            var eanIdsToIds = ImportRegions(Regions.ToArray(), FactoryOfRepositories.Regions(), 90000, p => p.CenterCoordinates);

            Regions = null;

            ImportLocalizedRegions(AdeptsToLocalizedRegions, FactoryOfRepositories.OfLocalized<LocalizedRegion>(), eanIdsToIds, DefaultLanguageId, CreatorId);

            var regionsEanIds = AdeptsToLocalizedRegions.Keys;

            AdeptsToLocalizedRegions = null;

            ImportRegionsToTypes(regionsEanIds, FactoryOfRepositories.RegionsToTypes(), eanIdsToIds, TypeOfRegionId,
                SubClassId, CreatorId);
        }

        private void ImportRegionsToTypes(
            ICollection<long> regionsEanIds,
            IRegionsToTypesRepository repository,
            IReadOnlyDictionary<long, int> eanIdsToIds,
            int typeOfRegionId,
            int subClassId,
            int creatorId
            )
        {
            LogBuild<RegionToType>();
            var regionsToTypes = BuildRegionsToTypes(regionsEanIds, eanIdsToIds, typeOfRegionId, subClassId, creatorId);
            var count = regionsToTypes.Length;
            LogAssembled(count);

            if (count <= 0) return;

            LogSave<RegionToType>();
            repository.BulkSave(regionsToTypes, count, rtt => rtt.SubClassId);
            LogSaved<RegionToType>();
        }

        protected RegionToType[] BuildRegionsToTypes(
            ICollection<long> regionsEanIds,
            IReadOnlyDictionary<long, int> eanIdsToIds,
            int typeOfRegionId,
            int subClassId,
            int creatorId
        )
        {
            var regionsToTypes = new Queue<RegionToType>();

            foreach (var regionEanId in regionsEanIds)
            {
                if (!eanIdsToIds.TryGetValue(regionEanId, out var id)) continue;
                var regionToType = new RegionToType
                {
                    Id = id,
                    ToId = typeOfRegionId,
                    SubClassId = subClassId,
                    CreatorId = creatorId
                };

                regionsToTypes.Enqueue(regionToType);
            }

            return regionsToTypes.ToArray();
        }

        public IPolygon CreatePolygon(string s)
        {
            var spl = s.Split(':');
            var coordinates= new Queue<Coordinate>();
            var closedPoint= Point.Empty;

           var pointsString = new StringBuilder();

            foreach (var s1 in spl)
            {
                var latLon = s1.Split(';');
               
                pointsString.Append($"{latLon[1]} {latLon[0]},");
                var point = CreatePoint(double.Parse(latLon[1],CultureInfo.InvariantCulture), double.Parse(latLon[0], CultureInfo.InvariantCulture));

                if (closedPoint == Point.Empty) closedPoint = point; 

                coordinates.Enqueue(point.Coordinate);

            }

            coordinates.Enqueue(closedPoint.Coordinate);

            //  pointsString.Append(pointsString.ToString().Split(',').First());


            return Geometry.DefaultFactory.CreatePolygon(coordinates.ToArray());
        }
    }
}