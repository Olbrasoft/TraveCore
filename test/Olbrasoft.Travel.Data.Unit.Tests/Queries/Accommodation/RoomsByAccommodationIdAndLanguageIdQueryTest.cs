using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Globalization;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    [TestFixture]
    internal class RoomsByAccommodationIdAndLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByAccommodationIdAndLanguageIdQuery_Of_IEnumerable_OfRoom()
        {
            //Arrange
            var type = typeof(ByPropertyIdAndLanguageIdQuery<IEnumerable<RoomDto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_IEnumerable_Of_Room()
        {
            //Arrange
            var type = typeof(TranslationQuery<IEnumerable<RoomDto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IQueryOfRoom()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<RoomDto>>);

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

        private static RoomsByPropertyIdAndLanguageIdQuery Query()
        {
            var providerMock = new Mock<IQueryDispatcher>();
            return new RoomsByPropertyIdAndLanguageIdQuery(providerMock.Object);
        }
    }
}