using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.IO;
using Olbrasoft.Travel.Data.Repositories;
using Olbrasoft.Travel.Data.Repositories.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Routing;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    public class PathsExtensionsCaptionsImporter : Importer
    {
        private IReadOnlyDictionary<int, int> _accommodationsExpediaIdsToIds;

        private IReadOnlyDictionary<int, int> AccommodationsExpediaIdsToIds
        {
            get =>
            _accommodationsExpediaIdsToIds ?? (_accommodationsExpediaIdsToIds =
            RepositoryFactory.MappedProperties<RealEstate>().ExpediaIdsToIds);
            set => _accommodationsExpediaIdsToIds = value;
        }

        protected HashSet<string> Paths = new HashSet<string>();
        protected HashSet<string> Extensions = new HashSet<string>();
        protected HashSet<string> Captions = new HashSet<string>();

        public PathsExtensionsCaptionsImporter(IProvider provider, IRepositoryFactory repositoryFactory,
            SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        public override void Import(string path)
        {
            LoadData(path);

            ImportPathsToPhotos(Paths, RepositoryFactory.PathsToPhotos(), CreatorId);

            ImportFilesExtensions(Extensions, RepositoryFactory.FilesExtensions(), CreatorId);

            ImportLocalizedCaptions(Captions, RepositoryFactory.LocalizedCaptions(), DefaultLanguageId, CreatorId);
        }

        private void ImportPathsToPhotos(IEnumerable<string> paths, IPathsToPhotosRepository repository, int creatorId)
        {
            LogBuild<PathToPhoto>();
            var pathsToPhotos = paths.Select(p => new PathToPhoto { Path = p, CreatorId = creatorId }).ToArray();
            var count = pathsToPhotos.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<PathToPhoto>();
            repository.BulkSave(pathsToPhotos);
            LogSaved<PathToPhoto>();
        }

        private void ImportFilesExtensions(IEnumerable<string> extensions, IFilesExtensionsRepository repository,
            int creatorId)
        {
            LogBuild<FileExtension>();
            var filesExtensions = extensions.Select(p => new FileExtension { Extension = p, CreatorId = creatorId })
                .ToArray();
            var count = filesExtensions.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<FileExtension>();
            repository.Save(filesExtensions);
            LogSaved<FileExtension>();
        }

        private void ImportLocalizedCaptions(IEnumerable<string> captions, ILocalizedCaptionsRepository repository,
            int languageId, int creatorId)
        {
            LogBuild<LocalizedCaption>();
            var localizedCaptions = captions
                .Select(p => new LocalizedCaption { Text = p, LanguageId = languageId, CreatorId = creatorId })
                .ToArray();
            var count = localizedCaptions.Length;
            LogAssembled(count);

            if (count <= 0) return;
            LogSave<LocalizedCaption>();
            repository.BulkSave(localizedCaptions);
            LogSaved<LocalizedCaption>();
        }

        protected override void RowLoaded(string[] items)
        {
            var eanHotelId = int.Parse(items[0]);

            if (!AccommodationsExpediaIdsToIds.ContainsKey(eanHotelId)) return;

            var caption = items[1];

            if (!string.IsNullOrEmpty(caption) && !Captions.Contains(caption)) Captions.Add(caption);

            var url = items[2];

            var path = ParsePath(url);

            if (!Paths.Contains(path)) Paths.Add(path);

            var extension = RemoveDots(Path.GetExtension(url)?.ToLower());

            if (!Extensions.Contains(extension)) Extensions.Add(extension);
        }

        public override void Dispose()
        {
            AccommodationsExpediaIdsToIds = null;
            Paths = null;
            Extensions = null;
            Captions = null;

            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}