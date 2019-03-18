using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Transfer;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Room = Olbrasoft.Travel.Data.Transfer.Objects.Room;

namespace Olbrasoft.Travel.Business.Services
{
    public class AccommodationService : Olbrasoft.Business.Service, IAccommodations
    {
        protected IAccommodationItemPhotoMerge Merger { get; }

        public AccommodationService(IQueryFactory queryFactory, IAccommodationItemPhotoMerge merger) : base(queryFactory)
        {
            Merger = merger;
        }

        public AccommodationDetail Get(int id, int languageId)
        {
            var query = AccommodationDetailQuery(id, languageId);
            
            return query.Execute();
        }

        public async Task<AccommodationDetail> GetAsync(int id, int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var accommodationDetail = await AccommodationDetailQuery(id, languageId).ExecuteAsync(cancellationToken);

            var accommodationPhotos = await AccommodationPhotosQuery(id).ExecuteAsync(cancellationToken);

            accommodationDetail.Photos =
                accommodationPhotos.Select(p =>
                    $"https://i.travelapi.com/hotels/{p.Path}/{p.Name}_b.{p.Extension}").ToArray();

            var rooms = await RoomsQuery(id, languageId).ExecuteAsync(cancellationToken);

            var photosOfRooms = await PhotosOfRoomsQuery(id).ExecuteAsync(cancellationToken);

            accommodationDetail.Rooms = FillPhotosOfRooms(rooms, photosOfRooms);

            accommodationDetail.Attributes = await AttributesQuery(id, languageId).ExecuteAsync(cancellationToken);

            return accommodationDetail;
        }

        private AttributesByAccommodationIdAndLanguageIdQuery AttributesQuery(int accommodationId, int languageId)
        {
            var query = QueryFactory.Get<AttributesByAccommodationIdAndLanguageIdQuery>();
            query.AccommodationId = accommodationId;
            query.LanguageId = languageId;
            return query;
        }

        private static IEnumerable<Room> FillPhotosOfRooms(IEnumerable<Room> rooms, IEnumerable<RoomPhoto> photosOfRooms)
        {
            var photosOfRoomsArray = photosOfRooms.ToArray();

            var ofRooms = rooms as Room[] ?? rooms.ToArray();
            foreach (var room in ofRooms)
            {
                var photos = photosOfRoomsArray.Where(p => p.RoomIds.Contains(room.Id));

                room.Photos = photos.Select(p =>
                    $"https://i.travelapi.com/hotels/{p.Path}/{p.Name}_b.{p.Extension}").ToArray();
            }

            return ofRooms;
        }

        private RoomPhotosByAccommodationIdQuery PhotosOfRoomsQuery(int accommodationId)
        {
            var query = QueryFactory.Get<RoomPhotosByAccommodationIdQuery>();
            query.AccommodationId = accommodationId;
            return query;
        }

        private RoomsByAccommodationIdAndLanguageIdQuery RoomsQuery(int id, int languageId)
        {
            var query = QueryFactory.Get<RoomsByAccommodationIdAndLanguageIdQuery>();
            query.AccommodationId = id;
            query.LanguageId = languageId;
            return query;
        }

        private PhotosByAccommodationIdQuery AccommodationPhotosQuery(int accommodationId)
        {
            var query = QueryFactory.Get<PhotosByAccommodationIdQuery>();
            query.AccommodationId = accommodationId;
            return query;
        }

        public IResultWithTotalCount<AccommodationItem> Get(IPageInfo pagingSettings, int languageId, Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> sorting)
        {
            var query = GetPagedAccommodationItems(pagingSettings, languageId, sorting);
            var accommodationItems = query.Execute();

            var getDefaultPhotosOfAccommodations = GetDefaultPhotosOfAccommodations(accommodationItems.Result.Select(p => p.Id));

            var photosOfAccommodations = getDefaultPhotosOfAccommodations.Execute();

            accommodationItems = MergePhotos(accommodationItems, photosOfAccommodations);

            return accommodationItems;
        }

        public async Task<IResultWithTotalCount<AccommodationItem>> GetAsync(
            IPageInfo pagingSettings,
            int languageId,
            Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> sorting,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            var query = GetPagedAccommodationItems(pagingSettings, languageId, sorting);

            var accommodationItems = await query.ExecuteAsync(cancellationToken);

            var getDefaultPhotosOfAccommodations = GetDefaultPhotosOfAccommodations(accommodationItems.Result.Select(p => p.Id));

            var photosOfAccommodations = await getDefaultPhotosOfAccommodations.ExecuteAsync(cancellationToken);

            accommodationItems = MergePhotos(accommodationItems, photosOfAccommodations);

            return accommodationItems;
        }

        public Task<IEnumerable<Suggestion>> SuggestionsAsync(string[] terms, int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<AccommodationSuggestionsQuery>();
            query.Terms = terms;
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        private IResultWithTotalCount<AccommodationItem> MergePhotos(IResultWithTotalCount<AccommodationItem> master, IEnumerable<AccommodationPhoto> slave)
        {
            return Merger.Merge(master, slave);
        }

        private PhotosOfAccommodationsByAccommodationIdsQuery GetDefaultPhotosOfAccommodations(IEnumerable<int> accommodationIds)
        {
            var query = QueryFactory.Get<PhotosOfAccommodationsByAccommodationIdsQuery>();
            query.AccommodationIds = accommodationIds;
            query.OnlyDefaultPhotos = true;
            return query;
        }

        private PagedAccommodationItemsByLanguageIdQuery GetPagedAccommodationItems(
            IPageInfo pagingSettings, int languageId, Func<IQueryable<LocalizedRealEstate>, IOrderedQueryable<LocalizedRealEstate>> sorting
        )
        {
            var query = QueryFactory.Get<PagedAccommodationItemsByLanguageIdQuery>();
            query.Paging = pagingSettings;
            query.LanguageId = languageId;
            query.Sorting = sorting;
            return query;
        }

        private AccommodationDetailByAccommodationIdAndLanguageIdQuery AccommodationDetailQuery(int id, int languageId)
        {
            var query = QueryFactory.Get<AccommodationDetailByAccommodationIdAndLanguageIdQuery>();

            query.AccommodationId = id;
            query.LanguageId = languageId;
            return query;
        }
    }
}