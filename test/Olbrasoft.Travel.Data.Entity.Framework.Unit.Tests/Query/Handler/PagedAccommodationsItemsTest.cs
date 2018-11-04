using System.Linq;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class PagedAccommodationsItemsTest
    {
        [Test]
        public void Instance_Implement_Interface_IHandler()
        {
            //Arrange
            var localizedAccommodationsQueryableMock = new Mock<IQueryable<LocalizedAccommodation>>();

            var localizedAccommodationsMock = new Mock<IHaveGlobalizationQueryable<LocalizedAccommodation>>();
            localizedAccommodationsMock.Setup(p => p.Queryable).Returns(localizedAccommodationsQueryableMock.Object);

            var projectionMock = new Mock<IProjection>();
            //Act
            var handler = new PagedAccommodationItems(localizedAccommodationsMock.Object,projectionMock.Object);

            //Assert
            Assert.IsInstanceOf<IHandle<GetPagedAccommodationItems, IResultWithTotalCount<AccommodationItem>>>(handler);
        }
    }
}