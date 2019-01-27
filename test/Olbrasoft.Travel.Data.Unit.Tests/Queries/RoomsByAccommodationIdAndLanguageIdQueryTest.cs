using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Queries;
using Olbrasoft.Globalization;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    [TestFixture]
    internal class RoomsByAccommodationIdAndLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByAccommodationIdAndLanguageIdQuery_Of_IEnumerable_OfRoom()
        {
            //Arrange
            var type = typeof(ByAccommodationIdAndLanguageIdQuery<IEnumerable<Room>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IEnumerable_Of_Room()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<IEnumerable<Room>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IQueryOfRoom()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<Room>>);

            //Act
            var query = Query();

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
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveAccommodationId()
        {
            //Arrange
            var type = typeof(IHaveAccommodationId);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static RoomsByAccommodationIdAndLanguageIdQuery Query()
        {
            var providerMock = new Mock<IProvider>();
            return new RoomsByAccommodationIdAndLanguageIdQuery(providerMock.Object);
        }
    }
}