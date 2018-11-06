using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using Olbrasoft.Globalization;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Data.Unit.Tests.Query
{
    [TestFixture]
    internal class GetRoomsTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryOfRoom()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<Room>>);
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new GetRooms(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveLanguageIdOfInteger()
        {
            //Arrange
            var type = typeof(IHaveLanguageId<int>);  

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type,query);

        }

        [Test]
        public void Instance_Implement_Interface_IHaveAccommodationId()
        {
            //Arrange
            var type = typeof(IHaveAccommodationId);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type,query);
        }

        private static GetRooms Query()
        {
            var providerMock = new Mock<IProvider>();
            return new GetRooms(providerMock.Object);
        }
    }
}