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
using Olbrasoft.Travel.Data.Queries.Accommodation;

namespace Olbrasoft.Travel.Business.Unit.Tests.Services
{
    [TestFixture]
    internal class RealEstateServiceTest
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
            Assert.IsInstanceOf<RealEstateDetail>(accommodationDetail);
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
            Assert.IsInstanceOf<Task<RealEstateDetail>>(accommodationDetailTask);
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
            Assert.IsInstanceOf<Task<RealEstateDetail>>(accommodationDetailTask);
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
            Assert.IsInstanceOf<IResultWithTotalCount<RealEstateItem>>(accommodationItems);
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
            Assert.IsInstanceOf<Task<IResultWithTotalCount<RealEstateItem>>>(accommodationItemsTask);
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
            Assert.IsInstanceOf<Task<IResultWithTotalCount<RealEstateItem>>>(accommodationItemsTask);
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

        private static RealEstateService AccommodationsService()
        {
            var queryDispatcher = new Mock<IQueryDispatcher>();

            queryDispatcher.Setup(p => p.Dispatch(It.IsAny<RealEstateDetailByRealEstateIdAndLanguageIdQuery>()))
                .Returns(new RealEstateDetail());

            var items = new[]
            {
               new RealEstateItem
               {
                   Id = 1
               }
            };

            var result = new ResultWithTotalCount<RealEstateItem>
            {
                Result = items
            };

            queryDispatcher.Setup(p => p.Dispatch(It.IsAny<PagedRealEstateItemsByLanguageIdQuery>())).Returns(result);

            var queryFactoryMock = new Mock<IQueryFactory>();

            queryFactoryMock.Setup(p => p.Get<RealEstateDetailByRealEstateIdAndLanguageIdQuery>())
                .Returns(new RealEstateDetailByRealEstateIdAndLanguageIdQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.Get<PagedRealEstateItemsByLanguageIdQuery>())
                .Returns(new PagedRealEstateItemsByLanguageIdQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.Get<PhotosOfAccommodationsByAccommodationIdsQuery>())
                .Returns(new PhotosOfAccommodationsByAccommodationIdsQuery(queryDispatcher.Object));

            queryFactoryMock.Setup(p => p.Get<RealEstatesSuggestionsQuery>())
                .Returns(new RealEstatesSuggestionsQuery(queryDispatcher.Object));

            var mockMerger = new RealEstateItemPhotoMerge();

            return new RealEstateService(queryFactoryMock.Object, mockMerger);
        }
    }
}