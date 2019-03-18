using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class ChainsImporter : Importer
    {
        protected Queue<Chain> Chains = new Queue<Chain>();

        public ChainsImporter(IProvider provider, IRepositoryFactory repositoryFactory, SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!int.TryParse(items[0], out var ExpediaId) || ExpediaId < 0) return;

            Chains.Enqueue(new Chain
            {
                ExpediaId = ExpediaId,
                Name = items[1],
                CreatorId = CreatorId
            });
        }

        public override void Import(string path)
        {
            LoadData(path);

            if (Chains.Count <= 0) return;

            LogSave<Chain>();
            RepositoryFactory.MappedProperties<Chain>().BulkSave(Chains);
            LogSaved<Chain>();

            Chains = null;
        }
    }
}