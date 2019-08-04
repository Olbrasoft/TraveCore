using Moq;
using NUnit.Framework;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System.Threading.Tasks;
using Olbrasoft.Mapping;
using Olbrasoft.Querying;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Accommodation
{
    public class PagedPropertyItemsByRegionIdTranslationQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_PagedPropertyItemsTranslationQuery_Comma_Property_Comma_IResultWithTotalCount_Of_AccommodationItem()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<PagedPropertyItemsByRegionIdTranslationQuery, 
                    IResultWithTotalCount<PropertyItem>, PropertyToRegion>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IResultWithTotalCount_Of_AccommodationItem()
        {
            //Arrange
            var type = typeof(Task<IResultWithTotalCount<PropertyItem>>);
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new PagedPropertyItemsByRegionIdTranslationQuery(providerMock.Object) { RegionId = 1976 };

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static PagedPropertyItemsByRegionIdTranslationQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PagedPropertyItemsByRegionIdTranslationQueryHandler( projectorMock.Object, contextMock.Object);
            return handler;
        }
    }
}