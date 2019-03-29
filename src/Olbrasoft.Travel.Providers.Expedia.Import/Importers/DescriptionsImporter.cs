using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;
using Description = Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Accommodation.Description;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class DescriptionsImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsExpediaIdsToIds;

        protected IReadOnlyDictionary<int, int> AccommodationsExpediaIdsToIds
        {
            get => _accommodationsExpediaIdsToIds ?? (_accommodationsExpediaIdsToIds =
                       RepositoryFactory.MappedProperties<Property>().ExpediaIdsToIds);

            set => _accommodationsExpediaIdsToIds = value;
        }

        private IReadOnlyDictionary<string, int> _languagesEanLanguageCodesToIds;

        protected IReadOnlyDictionary<string, int> LanguagesEanLanguageCodesToIds
        {
            get => _languagesEanLanguageCodesToIds ?? (_languagesEanLanguageCodesToIds =
                       RepositoryFactory.Languages().EanLanguageCodesToIds);

            set => _languagesEanLanguageCodesToIds = value;
        }

        protected int TypeOfDescriptionId { get; set; }

        protected Queue<DescriptionTranslation> Descriptions = new Queue<DescriptionTranslation>();

        public DescriptionsImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (
                !int.TryParse(items[0], out var eanHotelId) ||
                !AccommodationsExpediaIdsToIds.TryGetValue(eanHotelId, out var accommodationId) ||
                !LanguagesEanLanguageCodesToIds.TryGetValue(items[1], out var languageId)
            ) return;

            var description = new DescriptionTranslation
            {
                PropertyId = accommodationId,
                Id = TypeOfDescriptionId,
                LanguageId = languageId,
                Text = items[2],
                CreatorId = CreatorId
            };

            Descriptions.Enqueue(description);
        }

        public override void Import(string path)
        {
            const string general = "General";
            var typesOfDescriptionsRepository = RepositoryFactory.Names<Data.Accommodation.Description>();

            if (!typesOfDescriptionsRepository.NamesToIds.ContainsKey(general))
            {
                typesOfDescriptionsRepository.Add(new Data.Accommodation.Description { Name = general, CreatorId = CreatorId });
            }

            TypeOfDescriptionId = typesOfDescriptionsRepository.GetId(general);

            LoadData(path);

            AccommodationsExpediaIdsToIds = null;
            LanguagesEanLanguageCodesToIds = null;

            if (Descriptions.Count <= 0) return;

            LogSave<Description>();
            RepositoryFactory.AccommodationDescriptions().BulkSave(Descriptions, 160000);
            LogSaved<Description>();

            Descriptions = null;
        }
    }
}