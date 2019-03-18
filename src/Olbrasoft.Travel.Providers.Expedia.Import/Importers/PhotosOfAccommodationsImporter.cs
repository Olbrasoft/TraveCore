using System;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Providers.Expedia.Import.Importers
{
    internal class PhotosOfAccommodationsImporter : BasePhotosRelationalToAccommodationImporter
    {
        private IReadOnlyDictionary<string, int> _captionsToIds;

        protected IReadOnlyDictionary<string, int> CaptionsToIds
        {
            get =>
                _captionsToIds ?? (_captionsToIds = RepositoryFactory.LocalizedCaptions()
                    .GetLocalizedCaptionsTextsToIds(DefaultLanguageId));

            set => _captionsToIds = value;
        }

        public PhotosOfAccommodationsImporter(IProvider provider, IRepositoryFactory repositoryFactory,
            SharedProperties sharedProperties, ILoggingImports logger)
            : base(provider, repositoryFactory, sharedProperties, logger)
        {
        }

        protected override void RowLoaded(string[] items)
        {
            if (!TryBuildPhotoOfAccommodation(items, 2, out var photoOfAccommodation)) return;

            photoOfAccommodation = IfExistsCaptionAddLink(photoOfAccommodation, CaptionsToIds, items[1]);

            PhotosOfAccommodations.Add(photoOfAccommodation);
        }

        private static Photo IfExistsCaptionAddLink(Photo photo,
            IReadOnlyDictionary<string, int> captionsToIds, string caption)
        {
            if (!string.IsNullOrEmpty(caption) && captionsToIds.TryGetValue(caption, out var captionId))
            {
                photo.CaptionId = captionId;
            }

            return photo;
        }

        public override void Import(string path)
        {
            LoadData(path);
            var count = PhotosOfAccommodations.Count;

            WriteLog($"Assembled {count} {typeof(Photo)}.");

            if (count <= 0) return;
            LogSave<Photo>();
            RepositoryFactory.PhotosOfAccommodations().BulkSave(PhotosOfAccommodations);
            LogSaved<Photo>();
        }

        public override void Dispose()
        {
            CaptionsToIds = null;

            GC.SuppressFinalize(this);
            base.Dispose();
        }
    }
}