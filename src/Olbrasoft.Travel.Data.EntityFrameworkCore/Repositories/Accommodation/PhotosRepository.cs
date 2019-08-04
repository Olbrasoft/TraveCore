using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Repositories.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories.Accommodation
{
    public class PhotosRepository : TravelRepository<Photo>, IPhotosRepository
    {
        public PhotosRepository(DbContext context) : base(context)
        {
        }

        public void BulkSave(IEnumerable<Photo> photosOfAccommodations, int batchSize,
            params Expression<Func<Photo, object>>[] ignorePropertiesWhenUpdating)
        {
            if (Exists())
            {
                var photosOfAccommodationsForStored = RebuildIds(photosOfAccommodations.ToArray());

                //var forInsert = photosOfAccommodationsForStored.Where(poa => poa.Id == 0).ToArray();
                //var forUpdate = photosOfAccommodationsForStored.Where(poa => poa.Id != 0).ToArray();

                BulkInsert(photosOfAccommodationsForStored.Where(poa => poa.Id == 0));

                BulkUpdate(photosOfAccommodationsForStored.Where(poa => poa.Id != 0), batchSize, ignorePropertiesWhenUpdating);
            }
            else
            {


                BulkInsert(photosOfAccommodations, batchSize);

            }
        }

        public void BulkSave(IEnumerable<Photo> photosOfAccommodations, params Expression<Func<Photo, object>>[] ignorePropertiesWhenUpdating)
        {
            BulkSave(photosOfAccommodations, 360000, ignorePropertiesWhenUpdating);
        }

        private Photo[] RebuildIds(Photo[] photos)
        {
            var pathsAndFilesNamesToIds = GetPathIdsAndFileIdsAndExtensionIdsToIds();

            foreach (var photoOfAccommodation in photos.Where(poa => poa.Id == 0))
            {
                if (pathsAndFilesNamesToIds.TryGetValue(
                    new Tuple<int, string, int>(photoOfAccommodation.PathToPhotoId, photoOfAccommodation.FileName,
                        photoOfAccommodation.FileExtensionId), out var id))
                {
                    photoOfAccommodation.Id = id;
                }
            }
            return photos;
        }

        public IReadOnlyDictionary<Tuple<int, string, int>, int> GetPathIdsAndFileIdsAndExtensionIdsToIds()
        {
            return AsQueryable()
                .Select(poa => new
                {
                    poa.Id,
                    poa.PathToPhotoId,
                    poa.FileName,
                    poa.FileExtensionId
                }).ToArray()
                .ToDictionary(k => new Tuple<int, string, int>(k.PathToPhotoId, k.FileName, k.FileExtensionId),
                    v => v.Id);
        }

        //public IReadOnlyDictionary<Tuple<int, string, int>, int> GetPathIdsAndFileIdsAndExtensionIdsToIds(IEnumerable<int> pathIds)
        //{
        //    var storedPhotosOfAccommodations = new List<Photo>();

        //    foreach (var items in pathIds.SplitToEanumerableOfList(8000))
        //    {
        //        storedPhotosOfAccommodations.AddRange(
        //            AsQueryable()
        //            .Where(poa => items.Contains(poa.PathToPhotoId))
        //            .Select(poa => new
        //            {
        //                poa.Id,
        //                poa.PathToPhotoId,
        //                poa.FileName,
        //                poa.FileExtensionId
        //            }).ToArray()
        //                .Select(a => new Photo
        //                {
        //                    Id = a.Id,
        //                    PathToPhotoId = a.PathToPhotoId,
        //                    FileName = a.FileName,
        //                    FileExtensionId = a.FileExtensionId
        //                }));
        //    }

        //    return storedPhotosOfAccommodations.ToDictionary(
        //        item => new Tuple<int, string, int>(item.PathToPhotoId, item.FileName, item.FileExtensionId),
        //        item => item.Id);
        //}
    }
}