using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Localization;
using System.Collections.Generic;
using System.Linq;
using Olbrasoft.Travel.Data.Suggestion;
using Olbrasoft.Travel.Suggestion;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class RealEstateTypesImporter : Importer
    {
        protected IDictionary<int, string> ExpediaIdsToNames = new Dictionary<int, string>();

        public RealEstateTypesImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
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

            var typesOfAccommodationsExpediaIdsToIds = ImportRealEstateTypes(ExpediaIdsToNames.Keys,
                RepositoryFactory.MappedProperties<RealEstateCategory>(), CreatorId);

            ImportLocalizedTypesOfAccommodations(ExpediaIdsToNames,
                RepositoryFactory.Localized<LocalizedRealEstateCategory>(), typesOfAccommodationsExpediaIdsToIds, DefaultLanguageId,
                CreatorId);

            ExpediaIdsToNames = null;
        }

        private void ImportLocalizedTypesOfAccommodations(IDictionary<int, string> expediaIdsToNames,
            ILocalizedRepository<LocalizedRealEstateCategory> repository,
            IReadOnlyDictionary<int, int> typesOfAccommodationsExpediaIdsToIds,
            int languageId,
            int creatorId)
        {
            LogBuild<LocalizedRealEstateCategory>();
            var localizedRealEstateTypes = BuildLocalizedTypesOfAccommodations(expediaIdsToNames,
                typesOfAccommodationsExpediaIdsToIds, languageId, creatorId);
            var count = localizedRealEstateTypes.Length;

            if (count <= 0) return;

            LogSave<LocalizedRealEstateCategory>();
            repository.BulkSave(localizedRealEstateTypes, count);
            LogSaved<LocalizedRealEstateCategory>();
        }

        private static LocalizedRealEstateCategory[] BuildLocalizedTypesOfAccommodations(
            IDictionary<int, string> expediaIdsToNames,
            IReadOnlyDictionary<int, int> typesOfAccommodationsExpediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            var localizedTypesOfAccommodations = new Queue<LocalizedRealEstateCategory>();

            foreach (var propertyType in expediaIdsToNames)
            {
                if (!typesOfAccommodationsExpediaIdsToIds.TryGetValue(propertyType.Key, out var id)) continue;

                var localizedTypeOfAccommodation = new LocalizedRealEstateCategory
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

        private IReadOnlyDictionary<int, int> ImportRealEstateTypes(
            IEnumerable<int> expediaIds,
            IMappingToProvidersRepository<RealEstateCategory> repository,
            int creatorId
        )
        {
            LogBuild<RealEstateCategory>();
            var typesOfAccommodations = BuildRealEstateTypes(expediaIds, creatorId);
            var count = typesOfAccommodations.Length;
            LogAssembled(count);

            if (count <= 0) return repository.ExpediaIdsToIds;

            LogSave<RealEstateCategory>();
            repository.BulkSave(typesOfAccommodations);
            LogSaved<RealEstateCategory>();

            return repository.ExpediaIdsToIds;
        }

        private static RealEstateCategory[] BuildRealEstateTypes(IEnumerable<int> expediaIds,
            int creatorId
        )
        {
            return expediaIds.Select(ei => new RealEstateCategory
            {
                ExpediaId = ei,
                CreatorId = creatorId,
                SuggestionCategoryId = (int)SuggestionCategories.RealEstates
            }).ToArray();
        }
    }
}