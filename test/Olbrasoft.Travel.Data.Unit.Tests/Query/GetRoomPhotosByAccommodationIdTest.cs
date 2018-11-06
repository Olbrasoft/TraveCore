using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Data.Unit.Tests.Query
{
    [TestFixture]
    internal class GetRoomPhotosByAccommodationIdTest
    {
        [Test]
        public void Instance_Implement_Interface_IQuery()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<RoomPhoto>>);
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new GetRoomPhotosByAccommodationId(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveAccommodationId()
        {
            //Arrange
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new GetRoomPhotosByAccommodationId(providerMock.Object);

            //Assert
            Assert.IsInstanceOf<IHaveAccommodationId>(query);
        }
    }
}