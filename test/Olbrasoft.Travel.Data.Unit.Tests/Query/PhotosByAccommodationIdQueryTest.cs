using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Data.Unit.Tests.Query
{
    [TestFixture]
    internal class PhotosByAccommodationIdQueryTest
    {

        [Test]
        public void Instance_Is_AccommodationIdQuery_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(ByAccommodationIdQuery<IEnumerable<AccommodationPhoto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type,query);

        }

        [Test]
        public void Instance_Is_QueryWithDependentDispatcher_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(QueryWithDependentProvider<IEnumerable<AccommodationPhoto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void AccommodationId()
        {
            //Arrange
            var query = Query();
            query.AccommodationId = int.MaxValue;

            //Act
            var accommodationId = query.AccommodationId;

            //Assert
            Assert.IsTrue(accommodationId == int.MaxValue);
        }

        private static PhotosByAccommodationIdQuery Query()
        {
            var dispatcher = new Mock<IProvider>();

            return new PhotosByAccommodationIdQuery(dispatcher.Object);
        }
    }
}