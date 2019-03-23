using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Geography
{
    [TestFixture]
    internal class RoomPhotosByAccommodationIdQueryTest
    {
        [Test]
        public void Instance_Is_ByAccommodationIdQuery_Of_IEnumerable_Of_RoomPhoto()
        {
            //Arrange
            var type = typeof(ByRealEstateIdQuery<IEnumerable<RoomPhoto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IQuery()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<RoomPhoto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static RoomPhotosByRealEstateIdQuery Query()
        {
            var providerMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new RoomPhotosByRealEstateIdQuery(providerMock.Object);
            return query;
        }

        [Test]
        public void Instance_Implement_Interface_IHaveAccommodationId()
        {
            //Arrange
            var providerMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new RoomPhotosByRealEstateIdQuery(providerMock.Object);

            //Assert
            Assert.IsInstanceOf<IHaveAccommodationId>(query);
        }
    }
}