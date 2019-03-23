using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    [TestFixture]
    internal class PhotosByAccommodationIdQueryTest
    {
        [Test]
        public void Instance_Is_AccommodationIdQuery_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(ByRealEstateIdQuery<IEnumerable<RealEstatePhoto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_QueryWithDependentDispatcher_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(Query<IEnumerable<RealEstatePhoto>>);

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

        private static PhotosByRealEstateIdQuery Query()
        {
            var dispatcher = new Mock<IQueryDispatcher>();

            return new PhotosByRealEstateIdQuery(dispatcher.Object);
        }
    }
}