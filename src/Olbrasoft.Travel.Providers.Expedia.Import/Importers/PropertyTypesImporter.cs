using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Suggestion;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class PropertyTypesImporter : Importer
    {
        protected IDictionary<int, string> ExpediaIdsToNames = new Dictionary<int, string>();

        public PropertyTypesImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!int.TryParse(items[0], out var expediaId)) return;

            ExpediaIdsToNames.Add(expediaId, items[2]);
        }

        public override void Import(string path)
        {
            LoadData(path);

            var typesOfAccommodationsExpediaIdsToIds = ImportPropertyTypes(ExpediaIdsToNames.Keys,
                RepositoryFactory.MappedProperties<PropertyType>(), CreatorId);

            ImportLocalizedTypesOfAccommodations(ExpediaIdsToNames,
                RepositoryFactory.Localized<PropertyTypeTranslation>(), typesOfAccommodationsExpediaIdsToIds, DefaultLanguageId,
                CreatorId);

            ExpediaIdsToNames = null;
        }

        private void ImportLocalizedTypesOfAccommodations(IDictionary<int, string> expediaIdsToNames,
            ITranslationsRepository<PropertyTypeTranslation> repository,
            IReadOnlyDictionary<int, int> typesOfAccommodationsExpediaIdsToIds,
            int languageId,
            int creatorId)
        {
            LogBuild<PropertyTypeTranslation>();
            var localizedRealEstateTypes = BuildLocalizedTypesOfAccommodations(expediaIdsToNames,
                typesOfAccommodationsExpediaIdsToIds, languageId, creatorId);
            var count = localizedRealEstateTypes.Length;

            if (count <= 0) return;

            LogSave<PropertyTypeTranslation>();
            repository.BulkSave(localizedRealEstateTypes, count);
            LogSaved<PropertyTypeTranslation>();
        }

        private static PropertyTypeTranslation[] BuildLocalizedTypesOfAccommodations(
            IDictionary<int, string> expediaIdsToNames,
            IReadOnlyDictionary<int, int> typesOfAccommodationsExpediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            var localizedTypesOfAccommodations = new Queue<PropertyTypeTranslation>();

            foreach (var propertyType in expediaIdsToNames)
            {
                if (!typesOfAccommodationsExpediaIdsToIds.TryGetValue(propertyType.Key, out var id)) continue;

                var localizedTypeOfAccommodation = new PropertyTypeTranslation
                {
                    Id = id,
                    LanguageId = languageId,
                    Name = propertyType.Value,
                    CreatorId = creatorId
                };

                localizedTypesOfAccommodations.Enqueue(localizedTypeOfAccommodation);
            }
            return localizedTypesOfAccommodations.ToArray();
        }

        private IReadOnlyDictionary<int, int> ImportPropertyTypes(
            IEnumerable<int> expediaIds,
            IMappingToProvidersRepository<PropertyType> repository,
            int creatorId
        )
        {
            LogBuild<PropertyType>();
            var typesOfAccommodations = BuildPropertyTypes(expediaIds, creatorId);
            var count = typesOfAccommodations.Length;
            LogAssembled(count);

            if (count <= 0) return repository.ExpediaIdsToIds;

            LogSave<PropertyType>();
            repository.BulkSave(typesOfAccommodations);
            LogSaved<PropertyType>();

            return repository.ExpediaIdsToIds;
        }

        private static PropertyType[] BuildPropertyTypes(IEnumerable<int> expediaIds,
            int creatorId
        )
        {
            return expediaIds.Select(ei => new PropertyType
            {
                ExpediaId = ei,
                CreatorId = creatorId,
            }).ToArray();
        }
    }
}