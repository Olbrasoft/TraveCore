using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Geography
{
    [TestFixture]
    internal class RoomPhotosByAccommodationIdQueryTest
    {
        [Test]
        public void Instance_Is_ByAccommodationIdQuery_Of_IEnumerable_Of_RoomPhoto()
        {
            //Arrange
            var type = typeof(PropertyQuery<IEnumerable<RoomPhotoDto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IQuery()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<RoomPhotoDto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static RoomPhotosPropertyQuery Query()
        {
            var providerMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new RoomPhotosPropertyQuery(providerMock.Object);
            return query;
        }

        [Test]
        public void Instance_Implement_Interface_IHaveAccommodationId()
        {
            //Arrange
            var providerMock = new Mock<IQueryDispatcher>();

            //Act
            var query = new RoomPhotosPropertyQuery(providerMock.Object);

            //Assert
            Assert.IsInstanceOf<IHaveAccommodationId>(query);
        }
    }
}