using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class RegionsTypesOfCitiesImporter : RegionsTypesOfCitiesAndNeighborhoodsImporter
    {
        public RegionsTypesOfCitiesImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
            SubtypeId = RepositoryFactory.Names<RegionSubtype>().GetId("City");
            SubclassId = RepositoryFactory.Names<Subclass>().GetId("city");
        }
    }
}