using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Business.Services;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Business.Unit.Tests.Services
{
    [TestFixture]
    internal class AccommodationServiceTest
    {
        [Test]
        public void Instance_Is_Facade()
        {
            //Arrange
            var type = typeof(Olbrasoft.Business.Service);

            //Act
            var facade = AccommodationsService();

            //Assert
            Assert.IsInstanceOf(type, facade);
        }

        [Test]
        public void Instance_Implement_Interfaces()
        {
            //Arrange
            var type = typeof(IAccommodations);

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
            IAccommodations facade = AccommodationsService();
            const int languageId = 1033;
            const int id = 1;

            //Act
            var accommodationDetail = facade.Get(id, languageId);

            //Assert
            Assert.IsInstanceOf<AccommodationDetail>(accommodationDetail);
        }

        [Test]
        public void GetAsync_With_CancellationToken_Return_TaskOfAccommodationDetail()
        {
            //Arrange
            IAccommodations facade = AccommodationsService();
            const int languageId = 1033;
            const int id = 1;

            //Act
            var accommodationDetailTask = facade.GetAsync(id, languageId, CancellationToken.None);

            //Assert
            Assert.IsInstanceOf<Task<AccommodationDetail>>(accommodationDetailTask);
        }

        [Test]
        public void GetAsync_Return_TaskOfAccommodationDetail()
        {
            //Arrange
            IAccommodations facade = AccommodationsService();
            const int languageId = 1033;
            const int id = 1;

            //Act
            var accommodationDetailTask = facade.GetAsync(id, languageId);

            //Assert
            Assert.IsInstanceOf<Task<AccommodationDetail>>(accommodationDetailTask);
        }

        [Test]
        public void Get_Return_PagedList_Of_AccommodationItem()
        {
            //Arrange
            IAccommodations facade = AccommodationsService();
            const int languageId = 1033;
            var pagingMock = new Mock<IPageInfo>();

            //Act
            var accommodationItems = facade.Get(pagingMock.Object, languageId, null);

            //Assert
            Assert.IsInstanceOf<IResultWithTotalCount<AccommodationItem>>(accommodationItems);
        }

        [Test]
        public void GetAsync_With_CancellationToken_Return_TaskOfPagedListOfAccommodationItem()
        {
            //Arrange
            IAccommodations facade = AccommodationsService();
            const int languageId = 1033;
            var pagingMock = new Mock<IPageInfo>();

            //Act
            var cancellationToken = new CancellationToken();
            var accommodationItemsTask = facade.GetAsync(pagingMock.Object, languageId, null, cancellationToken);

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<AccommodationItem>>>(accommodationItemsTask);
        }

        [Test]
        public void GetAsync_Return_TaskOfPagedListOfAccommodationItem()
        {
            //Arrange
            IAccommodations facade = AccommodationsService();
            const int languageId = 1033;
            var pagingMock = new Mock<IPageInfo>();

            //Act
            var accommodationItemsTask = facade.GetAsync(pagingMock.Object, languageId, null);

            //Assert
            Assert.IsInstanceOf<Task<IResultWithTotalCount<AccommodationItem>>>(accommodationItemsTask);
        }

        [Test]
        public void SuggestionsAsync_Returns_Task_Of_IEnumerable_Of_Suggestions()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<Suggestion>>);
            var service = AccommodationsService();
            var terms = new[] { "Some term" };
            var languageId = 1033;

            //Act
            var result = service.SuggestionsAsync(terms, languageId);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static AccommodationService AccommodationsService()
        {
            var queryDispatcher = new Mock<IQueryDispatcher>();

            queryDispatcher.Setup(p => p.Dispatch(It.IsAny<AccommodationDetailByAccommodationIdAndLanguageIdQuery>()))
                .Returns(new AccommodationDetail());

            var items = new[]
            {
               new AccommodationItem
               {
                   Id = 1
               }
            };

            var result = new ResultWithTotalCount<AccommodationItem>
            {
                Result = items
            };

            queryDispatcher.Setup(p => p.Dispatch(It.IsAny<PagedAccommodationItemsByLanguageIdQuery>())).Returns(result);

            var queryFactoryMock = new Mock<IQueryFactory>();

            queryFactoryMock.Setup(p => p.Get<AccommodationDetailByAccommodationIdAndLanguageIdQuery>())
                .Returns(new AccommodationDetailByAccommodationIdAndLanguageIdQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.Get<PagedAccommodationItemsByLanguageIdQuery>())
                .Returns(new PagedAccommodationItemsByLanguageIdQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.Get<PhotosOfAccommodationsByAccommodationIdsQuery>())
                .Returns(new PhotosOfAccommodationsByAccommodationIdsQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.Get<RealEstatesSuggestionsQuery>())
                .Returns(new RealEstatesSuggestionsQuery(queryDispatcher.Object));

            var mockMerger = new AccommodationItemPhotoMerge();

            return new AccommodationService(queryFactoryMock.Object, mockMerger);
        }
    }
}