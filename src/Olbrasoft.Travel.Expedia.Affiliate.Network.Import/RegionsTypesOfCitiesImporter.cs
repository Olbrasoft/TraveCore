using Olbrasoft.Travel.Data.Entity.Geography;
using Olbrasoft.Travel.Data.Repository;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal class RegionsTypesOfCitiesImporter : RegionsTypesOfCitiesAndNeighborhoodsImporter
    {
        public RegionsTypesOfCitiesImporter(IProvider provider, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, factoryOfRepositories, sharedProperties, logger)
        {
            TypeOfRegionId = FactoryOfRepositories.GeographyNamesRepository<TypeOfRegion>().GetId("City");
            SubClassId = FactoryOfRepositories.GeographyNamesRepository<SubClass>().GetId("city");
        }
    }
}