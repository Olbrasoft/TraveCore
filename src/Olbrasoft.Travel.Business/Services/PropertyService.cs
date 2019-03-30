using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Business.Services
{
    public class PropertyService : Olbrasoft.Business.Service, IAccommodations
    {
        protected IPropertyItemPhotoMerge Merger { get; }

        public PropertyService(IQueryFactory queryFactory, IPropertyItemPhotoMerge merger) : base(queryFactory)
        {
            Merger = merger;
        }

        public PropertyDetail Get(int id, int languageId)
        {
            var query = AccommodationDetailQuery(id, languageId);

            return query.Execute();
        }

        public async Task<PropertyDetail> GetAsync(int id, int languageId, CancellationToken cancellationToken = default(CancellationToken))
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

        private AttributesByPropertyIdAndLanguageIdQuery AttributesQuery(int accommodationId, int languageId)
        {
            var query = QueryFactory.Get<AttributesByPropertyIdAndLanguageIdQuery>();
            query.PropertyId = accommodationId;
            query.LanguageId = languageId;
            return query;
        }

        private static IEnumerable<RoomDto> FillPhotosOfRooms(IEnumerable<RoomDto> rooms, IEnumerable<RoomPhotoDto> photosOfRooms)
        {
            var photosOfRoomsArray = photosOfRooms.ToArray();

            var ofRooms = rooms as RoomDto[] ?? rooms.ToArray();
            foreach (var room in ofRooms)
            {
                var photos = photosOfRoomsArray.Where(p => p.RoomIds.Contains(room.Id));

                room.Photos = photos.Select(p =>
                    $"https://i.travelapi.com/hotels/{p.Path}/{p.Name}_b.{p.Extension}").ToArray();
            }

            return ofRooms;
        }

        private RoomPhotosByPropertyIdQuery PhotosOfRoomsQuery(int accommodationId)
        {
            var query = QueryFactory.Get<RoomPhotosByPropertyIdQuery>();
            query.PropertyId = accommodationId;
            return query;
        }

        private RoomsByPropertyIdAndLanguageIdQuery RoomsQuery(int id, int languageId)
        {
            var query = QueryFactory.Get<RoomsByPropertyIdAndLanguageIdQuery>();
            query.PropertyId = id;
            query.LanguageId = languageId;
            return query;
        }

        private PhotosByPropertyIdQuery AccommodationPhotosQuery(int accommodationId)
        {
            var query = QueryFactory.Get<PhotosByPropertyIdQuery>();
            query.PropertyId = accommodationId;
            return query;
        }

        public IResultWithTotalCount<PropertyItem> Get(IPageInfo pagingSettings, int languageId, Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> sorting)
        {
            var query = GetPagedAccommodationItems(pagingSettings, languageId, sorting);
            var accommodationItems = query.Execute();

            var getDefaultPhotosOfAccommodations = GetDefaultPhotosOfAccommodations(accommodationItems.Result.Select(p => p.Id));

            var photosOfAccommodations = getDefaultPhotosOfAccommodations.Execute();

            accommodationItems = MergePhotos(accommodationItems, photosOfAccommodations);

            return accommodationItems;
        }

        public async Task<IResultWithTotalCount<PropertyItem>> GetAsync(
            IPageInfo pagingSettings,
            int languageId,
            Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> sorting,
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

        public Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string[] terms, int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<PropertiesSuggestionsQuery>();
            query.Terms = terms;
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        private IResultWithTotalCount<PropertyItem> MergePhotos(IResultWithTotalCount<PropertyItem> master, IEnumerable<PropertyPhotoDto> slave)
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

        private PagedPropertyItemsByLanguageIdQuery GetPagedAccommodationItems(
            IPageInfo pagingSettings, int languageId, Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> sorting
        )
        {
            var query = QueryFactory.Get<PagedPropertyItemsByLanguageIdQuery>();
            query.Paging = pagingSettings;
            query.LanguageId = languageId;
            query.Sorting = sorting;
            return query;
        }

        private PropertyDetailByPropertyIdAndLanguageIdQuery AccommodationDetailQuery(int id, int languageId)
        {
            var query = QueryFactory.Get<PropertyDetailByPropertyIdAndLanguageIdQuery>();

            query.PropertyId = id;
            query.LanguageId = languageId;
            return query;
        }
    }
}