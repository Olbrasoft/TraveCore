using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Paging;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Business.Services;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Business.Unit.Services
{
    [TestFixture]
    internal class PropertyServiceTest
    {
        [Test]
        public void Instance_Is_Facade()
        {
            //Arrange
            var type = typeof(Olbrasoft.Querying.Business.ServiceWithQueryFactory);

            //Act
            var facade = AccommodationsService();

            //Assert
            Assert.IsInstanceOf(type, facade);
        }

        [Test]
        public void Instance_Implement_Interfaces()
        {
            //Arrange
            var type = typeof(IProperties);

            //Act
            var facade = AccommodationsService();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf(type, facade);
            });
        }

        [Test]
        public void Get_Return_AccommodationDetail()
        {
            //Arrange
            IProperties facade = AccommodationsService();
            const int languageId = 1033;
            const int id = 1;

            //Act
            var accommodationDetail = facade.Get(id, languageId);

            //Assert
            Assert.IsInstanceOf<PropertyDetail>(accommodationDetail);
        }

        [Test]
        public void GetAsync_With_CancellationToken_Return_TaskOfAccommodationDetail()
        {
            //Arrange
            IProperties facade = AccommodationsService();
            const int languageId = 1033;
            const int id = 1;

            //Act
            var accommodationDetailTask = facade.GetAsync(id, languageId, CancellationToken.None);

            //Assert
            Assert.IsInstanceOf<Task<PropertyDetail>>(accommodationDetailTask);
        }

        [Test]
        public void GetAsync_Return_TaskOfAccommodationDetail()
        {
            //Arrange
            IProperties facade = AccommodationsService();
            const int languageId = 1033;
            const int id = 1;

            //Act
            var accommodationDetailTask = facade.GetAsync(id, languageId);

            //Assert
            Assert.IsInstanceOf<Task<PropertyDetail>>(accommodationDetailTask);
        }

        [Test]
        public void Get_Return_PagedList_Of_AccommodationItem()
        {
            //Arrange
            IProperties facade = AccommodationsService();
            const int languageId = 1033;
            var pagingMock = new Mock<IPageInfo>();

            //Act
            var accommodationItems = facade.Get(pagingMock.Object, languageId, null);

            //Assert
            Assert.IsInstanceOf<IResultWithTotalCount<PropertyItem>>(accommodationItems);
        }

        [Test]
        public void GetAsync_With_CancellationToken_Return_TaskOfPagedListOfAccommodationItem()
        {
            //Arrange
            IProperties facade = AccommodationsService();
            const int languageId = 1033;
            var pagingMock = new Mock<IPageInfo>();

            //Act
            var cancellationToken = new CancellationToken();
            var accommodationItemsTask = facade.GetAsync(pagingMock.Object, languageId, null, cancellationToken);

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<PropertyItem>>>(accommodationItemsTask);
        }

        [Test]
        public void GetAsync_Return_TaskOfPagedListOfAccommodationItem()
        {
            //Arrange
            IProperties service = AccommodationsService();
            const int languageId = 1033;
            var pagingMock = new Mock<IPageInfo>();

            //Act
            var accommodationItemsTask = service.GetAsync(pagingMock.Object, languageId, null);

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<PropertyItem>>>(accommodationItemsTask);
        }

        [Test]
        public void GetAsync_By_RegionId_Return_TaskOfPagedListOfAccommodationItem()
        {
            //Arrange
            const int regionId = 1976;
            IProperties service = AccommodationsService();
            const int languageId = 1033;
            var pagingMock = new Mock<IPageInfo>();

            //Act
            var accommodationItemsTask = service.GetAsync(regionId, pagingMock.Object, languageId, null);

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<PropertyItem>>>(accommodationItemsTask);
        }

        [Test]
        public void SuggestionsAsync_Returns_Task_Of_IEnumerable_Of_Suggestions()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<SuggestionDto>>);
            var service = AccommodationsService();
            var terms = new[] { "Some term" };
            var languageId = 1033;

            //Act
            var result = service.SuggestionsAsync(terms, languageId);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static PropertyService AccommodationsService()
        {
            var queryDispatcher = new Mock<IQueryDispatcher>();

            queryDispatcher.Setup(p => p.Dispatch(It.IsAny<PropertyDetailByPropertyIdAndLanguageIdQuery>()))
                .Returns(new PropertyDetail());

            var items = new[]
            {
               new PropertyItem
               {
                   Id = 1
               }
            };

            var result = new ResultWithTotalCount<PropertyItem>
            {
                Result = items
            };

            queryDispatcher.Setup(p => p.Dispatch(It.IsAny<PagedPropertyItemsTranslationQuery>())).Returns(result);

            var queryFactoryMock = new Mock<IQueryFactory>();

            queryFactoryMock.Setup(p => p.CreateQuery<PropertyDetailByPropertyIdAndLanguageIdQuery>())
                .Returns(new PropertyDetailByPropertyIdAndLanguageIdQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<PagedPropertyItemsTranslationQuery>())
                .Returns(new PagedPropertyItemsTranslationQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<PhotosOfAccommodationsByAccommodationIdsQuery>())
                .Returns(new PhotosOfAccommodationsByAccommodationIdsQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<PropertiesSuggestionsByTermsTranslationQuery>())
                .Returns(new PropertiesSuggestionsByTermsTranslationQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.CreateQuery<PagedPropertyItemsByRegionIdTranslationQuery>())
                .Returns(new PagedPropertyItemsByRegionIdTranslationQuery(queryDispatcher.Object));

            var mockMerger = new PropertyItemPhotoMerge();

            return new PropertyService(queryFactoryMock.Object, mockMerger);
        }
    }
}