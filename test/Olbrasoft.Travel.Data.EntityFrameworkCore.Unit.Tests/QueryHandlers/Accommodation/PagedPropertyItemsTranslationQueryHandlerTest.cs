using Moq;
using NUnit.Framework;
using Olbrasoft.Mapping;
using Olbrasoft.Paging;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System.Linq;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Accommodation
{
    [TestFixture]
    internal class PagedPropertyItemsTranslationQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_PagedPropertyItemsTranslationQuery_Comma_Property_Comma_IResultWithTotalCount_Of_AccommodationItem()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<PagedPropertyItemsTranslationQuery,
                    IResultWithTotalCount<PropertyItem>, Property>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void Inherits_From_PropertyQueryHandler_Of_PagedAccommodationItemsByLanguageIdQuery_Comma_IQueryable_Of_Accommodation_Comma_IResultWithTotalCount_Of_AccommodationItem()
        {
            //Arrange
            var type =
                typeof(QueryHandler<PagedPropertyItemsTranslationQuery, IQueryable<Property>,
                    IResultWithTotalCount<PropertyItem>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static PagedPropertyItemsTranslationQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PagedPropertyItemsTranslationQueryHandler(projectorMock.Object, contextMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IResultWithTotalCount_Of_AccommodationItem()
        {
            //Arrange
            var type = typeof(Task<IResultWithTotalCount<PropertyItem>>);
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new PagedPropertyItemsTranslationQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}