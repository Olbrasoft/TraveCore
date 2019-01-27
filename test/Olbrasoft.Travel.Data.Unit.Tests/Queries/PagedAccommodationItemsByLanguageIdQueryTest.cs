using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Queries;
using Olbrasoft.Pagination;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    [TestFixture]
    internal class PagedAccommodationItemsByLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IResultWithTotalCount_Of_AccommodationItem()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<IResultWithTotalCount<AccommodationItem>>);
            var providerMock = new Mock<IProvider>();
            
            //Act
            var query = new PagedAccommodationItemsByLanguageIdQuery(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type,query);

        }
    }
}