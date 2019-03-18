using System;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;
using Attribute = Olbrasoft.Travel.Data.Accommodation.Attribute;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    public class AccommodationsToAttributesDefaultLanguageImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsExpediaIdsToIds;
        private IReadOnlyDictionary<int, int> _attributesExpediaIdsToIds;

        protected IReadOnlyDictionary<int, int> AttributesExpediaIdsToIds
        {
            get => _attributesExpediaIdsToIds ?? (_attributesExpediaIdsToIds =
                       RepositoryFactory.MappedProperties<Attribute>().ExpediaIdsToIds);

            set => _attributesExpediaIdsToIds = value;
        }

        protected IReadOnlyDictionary<int, int> AccommodationsExpediaIdsToIds
        {
            get => _accommodationsExpediaIdsToIds ?? (_accommodationsExpediaIdsToIds =
                       RepositoryFactory.MappedProperties<RealEstate>().ExpediaIdsToIds);

            set => _accommodationsExpediaIdsToIds = value;
        }

        protected Queue<RealEstateToAttribute> AccommodationsToAttributes = new Queue<RealEstateToAttribute>();

        public AccommodationsToAttributesDefaultLanguageImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!int.TryParse(items[0], out var eanHotelId) ||
                !AccommodationsExpediaIdsToIds.TryGetValue(eanHotelId, out var accommodationId) ||
                !int.TryParse(items[1], out var eanAttributeId) ||
                !AttributesExpediaIdsToIds.TryGetValue(eanAttributeId, out var attributeId)
            ) return;

            var accommodationToAttribute = new RealEstateToAttribute
            {
                RealEstateId = accommodationId,
                AttributeId = attributeId,
                LanguageId = DefaultLanguageId,
                Text = items[3],
                CreatorId = CreatorId
            };

            AccommodationsToAttributes.Enqueue(accommodationToAttribute);
        }

        public override void Import(string path)
        {
            LoadData(path);
            AttributesExpediaIdsToIds = null;
            AccommodationsExpediaIdsToIds = null;

            if (AccommodationsToAttributes.Count <= 0) return;

            LogSave<RealEstateToAttribute>();
            RepositoryFactory.AccommodationsToAttributes().BulkSave(AccommodationsToAttributes);
            AccommodationsToAttributes = null;
            LogSaved<RealEstateToAttribute>();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}