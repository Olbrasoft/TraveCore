using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    [TestFixture]
    internal class PhotosByAccommodationIdQueryTest
    {
        [Test]
        public void Instance_Is_AccommodationIdQuery_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(PropertyQuery<IEnumerable<PropertyPhotoDto>>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_QueryWithDependentDispatcher_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(Query<IEnumerable<PropertyPhotoDto>>);

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
            query.PropertyId = int.MaxValue;

            //Act
            var accommodationId = query.PropertyId;

            //Assert
            Assert.IsTrue(accommodationId == int.MaxValue);
        }

        private static PhotosPropertyQuery Query()
        {
            var dispatcher = new Mock<IQueryDispatcher>();

            return new PhotosPropertyQuery(dispatcher.Object);
        }
    }
}