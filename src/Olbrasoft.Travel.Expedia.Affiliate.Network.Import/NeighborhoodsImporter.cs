using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Repository;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal class NeighborhoodsImporter : RegionsTypesOfCitiesAndNeighborhoodsImporter
    {
        public NeighborhoodsImporter(IProvider provider, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, factoryOfRepositories, sharedProperties, logger)
        {
            TypeOfRegionId = FactoryOfRepositories.GeographyNamesRepository<TypeOfRegion>().GetId("Neighborhood");
            SubClassId = FactoryOfRepositories.GeographyNamesRepository<SubClass>().GetId("neighbor");
        }
    }
}