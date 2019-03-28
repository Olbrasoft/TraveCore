using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries.Accommodation
{
    [TestFixture]
    internal class PhotosOfAccommodationsByAccommodationIdsQueryTest
    {
        [Test]
        public void Instance_Implement_Interface_IQuery_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(IQuery<IEnumerable<PropertyPhotoDto>>);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Is_QueryWithDependentDispatcher_Of_IEnumerable_OfAccommodationPhoto()
        {
            //Arrange
            var type = typeof(Query<IEnumerable<PropertyPhotoDto>>);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void AccommodationIds()
        {
            //Arrange
            var q = CreateQuery();
            q.AccommodationIds = new[] { 1, 2, 3 };

            //Act
            var ids = q.AccommodationIds;

            //Assert
            Assert.IsTrue(ids.First() == 1);
        }

        [Test]
        public void OnlyDefaultPhotos()
        {
            //Arrange
            var q = CreateQuery();

            //Act
            q.OnlyDefaultPhotos = true;

            //Assert
            Assert.IsTrue(q.OnlyDefaultPhotos);
        }

        private static PhotosOfAccommodationsByAccommodationIdsQuery CreateQuery()
        {
            var dispatcher = new Mock<IQueryDispatcher>();

            return new PhotosOfAccommodationsByAccommodationIdsQuery(dispatcher.Object);
        }
    }
}