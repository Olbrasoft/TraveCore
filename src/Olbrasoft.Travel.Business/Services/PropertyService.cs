using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Paging;

namespace Olbrasoft.Travel.Business.Services
{
    public class PropertyService : Olbrasoft.Querying.Business.ServiceWithQueryFactory, IProperties
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
            var query = GetQuery<AttributesByPropertyIdAndLanguageIdQuery>();
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

        private RoomPhotosPropertyQuery PhotosOfRoomsQuery(int accommodationId)
        {
            var query = GetQuery<RoomPhotosPropertyQuery>();
            query.PropertyId = accommodationId;
            return query;
        }

        private RoomsByPropertyIdAndLanguageIdQuery RoomsQuery(int id, int languageId)
        {
            var query = GetQuery<RoomsByPropertyIdAndLanguageIdQuery>();
            query.PropertyId = id;
            query.LanguageId = languageId;
            return query;
        }

        private PhotosPropertyQuery AccommodationPhotosQuery(int accommodationId)
        {
            var query = GetQuery<PhotosPropertyQuery>();
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
            CancellationToken cancellationToken = default
        )
        {
            var query = GetPagedAccommodationItems(pagingSettings, languageId, sorting);

            var accommodationItems = await query.ExecuteAsync(cancellationToken);

            var getDefaultPhotosOfAccommodations = GetDefaultPhotosOfAccommodations(accommodationItems.Result.Select(p => p.Id));

            var photosOfAccommodations = await getDefaultPhotosOfAccommodations.ExecuteAsync(cancellationToken);

            accommodationItems = MergePhotos(accommodationItems, photosOfAccommodations);

            return accommodationItems;
        }

        public async Task<IResultWithTotalCount<PropertyItem>> GetAsync(int regionId, IPageInfo pagingSettings, int languageId, Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> sorting,
            CancellationToken cancellationToken = default)
        {
            var query = BuildPagedPropertyItemsByRegionIdTranslationQuery(regionId, pagingSettings, languageId, sorting);

            var accommodationItems = await query.ExecuteAsync(cancellationToken);

            var getDefaultPhotosOfAccommodations = GetDefaultPhotosOfAccommodations(accommodationItems.Result.Select(p => p.Id));

            var photosOfAccommodations = await getDefaultPhotosOfAccommodations.ExecuteAsync(cancellationToken);

            accommodationItems = MergePhotos(accommodationItems, photosOfAccommodations);

            return accommodationItems;
        }

        private PagedPropertyItemsByRegionIdTranslationQuery BuildPagedPropertyItemsByRegionIdTranslationQuery(int regionId,
            IPageInfo pagingSettings, int languageId, Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> sorting)
        {
            var query = GetQuery<PagedPropertyItemsByRegionIdTranslationQuery>();
            query.Paging = pagingSettings;
            query.LanguageId = languageId;
            query.Sorting = sorting;
            query.RegionId = regionId;
            return query;
        }

        public Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string term, int languageId, CancellationToken token = default)
        {
            var query = GetQuery<PropertySuggestionsTranslationQuery>();
            query.Term = term;
            query.LanguageId = languageId;

            return query.ExecuteAsync(token);
        }

        public Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string[] terms, int languageId, CancellationToken token = default)
        {
            var query = GetQuery<PropertiesSuggestionsByTermsTranslationQuery>();
            query.Terms = terms;
            query.LanguageId = languageId;

            return query.ExecuteAsync(token);
        }

        private IResultWithTotalCount<PropertyItem> MergePhotos(IResultWithTotalCount<PropertyItem> master, IEnumerable<PropertyPhotoDto> slave)
        {
            return Merger.Merge(master, slave);
        }

        private PhotosOfAccommodationsByAccommodationIdsQuery GetDefaultPhotosOfAccommodations(IEnumerable<int> accommodationIds)
        {
            var query = GetQuery<PhotosOfAccommodationsByAccommodationIdsQuery>();
            query.AccommodationIds = accommodationIds;
            query.OnlyDefaultPhotos = true;
            return query;
        }

        private PagedPropertyItemsTranslationQuery GetPagedAccommodationItems(
            IPageInfo pagingSettings, int languageId, Func<IQueryable<PropertyTranslation>, IOrderedQueryable<PropertyTranslation>> sorting
        )
        {
            var query = GetQuery<PagedPropertyItemsTranslationQuery>();
            query.Paging = pagingSettings;
            query.LanguageId = languageId;
            query.Sorting = sorting;
            return query;
        }

        private PropertyDetailByPropertyIdAndLanguageIdQuery AccommodationDetailQuery(int id, int languageId)
        {
            var query = GetQuery<PropertyDetailByPropertyIdAndLanguageIdQuery>();

            query.PropertyId = id;
            query.LanguageId = languageId;
            return query;
        }
    }
}