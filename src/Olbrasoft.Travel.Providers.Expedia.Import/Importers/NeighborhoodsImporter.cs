using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class NeighborhoodsImporter : RegionsTypesOfCitiesAndNeighborhoodsImporter
    {
        public NeighborhoodsImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
            SubtypeId = RepositoryFactory.Names<RegionSubtype>().GetId("Neighborhood");
            SubclassId = RepositoryFactory.Names<Subclass>().GetId("neighbor");
        }
    }
}