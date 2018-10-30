using System.Collections.Generic;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Repository;
using Description = Olbrasoft.Travel.Expedia.Affiliate.Network.Data.Transfer.Object.Property.Description;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Import
{
    internal class DescriptionsImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsEanIdsToIds;

        protected IReadOnlyDictionary<int, int> AccommodationsEanIdsToIds
        {
            get => _accommodationsEanIdsToIds ?? (_accommodationsEanIdsToIds =
                       FactoryOfRepositories.MappedProperties<Accommodation>().EanIdsToIds);

            set => _accommodationsEanIdsToIds = value;
        }

        private IReadOnlyDictionary<string, int> _languagesEanLanguageCodesToIds;

        protected IReadOnlyDictionary<string, int> LanguagesEanLanguageCodesToIds
        {
            get => _languagesEanLanguageCodesToIds ?? (_languagesEanLanguageCodesToIds =
                       FactoryOfRepositories.Languages().EanLanguageCodesToIds);

            set => _languagesEanLanguageCodesToIds = value;
        }

        protected int TypeOfDescriptionId { get; set; }

        protected Queue<LocalizedDescriptionOfAccommodation> Descriptions = new Queue<LocalizedDescriptionOfAccommodation>();

        public DescriptionsImporter(IProvider provider, IFactoryOfRepositories factoryOfRepositories, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, factoryOfRepositories, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (
                !int.TryParse(items[0], out var eanHotelId) ||
                !AccommodationsEanIdsToIds.TryGetValue(eanHotelId, out var accommodationId) ||
                !LanguagesEanLanguageCodesToIds.TryGetValue(items[1], out var languageId)
            ) return;

            var description = new LocalizedDescriptionOfAccommodation
            {
                AccommodationId = accommodationId,
                TypeOfDescriptionId = TypeOfDescriptionId,
                LanguageId = languageId,
                Text = items[2],
                CreatorId = CreatorId
            };

            Descriptions.Enqueue(description);
        }

        public override void Import(string path)
        {
            const string general = "General";
            var typesOfDescriptionsRepository = FactoryOfRepositories.PropertyNamesRepository<TypeOfDescription>();

            if (!typesOfDescriptionsRepository.NamesToIds.ContainsKey(general))
            {
                typesOfDescriptionsRepository.Add(new TypeOfDescription { Name = general, CreatorId = CreatorId });
            }

            TypeOfDescriptionId = typesOfDescriptionsRepository.GetId(general);

            LoadData(path);

            AccommodationsEanIdsToIds = null;
            LanguagesEanLanguageCodesToIds = null;

            if (Descriptions.Count <= 0) return;

            LogSave<Description>();
            FactoryOfRepositories.DescriptionsOfAccommodations().BulkSave(Descriptions, 160000);
            LogSaved<Description>();

            Descriptions = null;
        }
    }
}