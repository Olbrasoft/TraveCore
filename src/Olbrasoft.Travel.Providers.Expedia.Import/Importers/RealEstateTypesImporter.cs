using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Localization;
using System.Collections.Generic;
using System.Linq;

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

            var typesOfAccommodationsExpediaIdsToIds = ImportTypesOfAccommodations(ExpediaIdsToNames.Keys,
                RepositoryFactory.MappedProperties<RealEstateType>(), CreatorId);

            ImportLocalizedTypesOfAccommodations(ExpediaIdsToNames,
                RepositoryFactory.Localized<LocalizedRealEstateType>(), typesOfAccommodationsExpediaIdsToIds, DefaultLanguageId,
                CreatorId);

            ExpediaIdsToNames = null;
        }

        private void ImportLocalizedTypesOfAccommodations(IDictionary<int, string> expediaIdsToNames,
            ILocalizedRepository<LocalizedRealEstateType> repository,
            IReadOnlyDictionary<int, int> typesOfAccommodationsExpediaIdsToIds,
            int languageId,
            int creatorId)
        {
            LogBuild<LocalizedRealEstateType>();
            var localizedTypesOfAccommodations = BuildLocalizedTypesOfAccommodations(expediaIdsToNames,
                typesOfAccommodationsExpediaIdsToIds, languageId, creatorId);
            var count = localizedTypesOfAccommodations.Length;

            if (count <= 0) return;

            LogSave<LocalizedRealEstateType>();
            repository.BulkSave(localizedTypesOfAccommodations, count);
            LogSaved<LocalizedRealEstateType>();
        }

        private static LocalizedRealEstateType[] BuildLocalizedTypesOfAccommodations(
            IDictionary<int, string> expediaIdsToNames,
            IReadOnlyDictionary<int, int> typesOfAccommodationsExpediaIdsToIds,
            int languageId,
            int creatorId
        )
        {
            var localizedTypesOfAccommodations = new Queue<LocalizedRealEstateType>();

            foreach (var propertyType in expediaIdsToNames)
            {
                if (!typesOfAccommodationsExpediaIdsToIds.TryGetValue(propertyType.Key, out var id)) continue;

                var localizedTypeOfAccommodation = new LocalizedRealEstateType
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

        private IReadOnlyDictionary<int, int> ImportTypesOfAccommodations(
            IEnumerable<int> expediaIds,
            IMappingToProvidersRepository<RealEstateType> repository,
            int creatorId
        )
        {
            LogBuild<RealEstateType>();
            var typesOfAccommodations = BuildTypesOfAccommodations(expediaIds, creatorId);
            var count = typesOfAccommodations.Length;
            LogAssembled(count);

            if (count <= 0) return repository.ExpediaIdsToIds;

            LogSave<RealEstateType>();
            repository.BulkSave(typesOfAccommodations);
            LogSaved<RealEstateType>();

            return repository.ExpediaIdsToIds;
        }

        private static RealEstateType[] BuildTypesOfAccommodations(IEnumerable<int> expediaIds,
            int creatorId
        )
        {
            return expediaIds.Select(ei => new RealEstateType
            {
                ExpediaId = ei,
                CreatorId = creatorId
            }).ToArray();
        }
    }
}