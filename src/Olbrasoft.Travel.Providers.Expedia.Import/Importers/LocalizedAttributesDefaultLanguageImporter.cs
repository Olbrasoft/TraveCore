using System;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;
using Attribute = Olbrasoft.Travel.Data.Accommodation.Attribute;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    public class LocalizedAttributesDefaultLanguageImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _attributesExpediaIdsToIds;

        protected IReadOnlyDictionary<int, int> AttributesExpediaIdsToIds
        {
            get => _attributesExpediaIdsToIds ?? (_attributesExpediaIdsToIds =
                       RepositoryFactory.MappedProperties<Attribute>().ExpediaIdsToIds);

            set => _attributesExpediaIdsToIds = value;
        }

        protected HashSet<AttributeTranslation> LocalizedAttributes = new HashSet<AttributeTranslation>();

        public LocalizedAttributesDefaultLanguageImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!int.TryParse(items[0], out var attributeExpediaId) ||
                !AttributesExpediaIdsToIds.TryGetValue(attributeExpediaId, out var id)) return;

            var localizedAttribute = new AttributeTranslation
            {
                Id = id,
                LanguageId = DefaultLanguageId,
                Description = items[2],
                CreatorId = CreatorId
            };

            LocalizedAttributes.Add(localizedAttribute);
        }

        public override void Import(string path)
        {
            LoadData(path);
            AttributesExpediaIdsToIds = null;

            if (LocalizedAttributes.Count <= 0) return;

            LogSave<AttributeTranslation>();
            RepositoryFactory.Localized<AttributeTranslation>().BulkSave(LocalizedAttributes);
            LocalizedAttributes = null;
            LogSaved<AttributeTranslation>();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}