using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class PhotosByAccommodationIdTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type =
                typeof(AsyncHandlerWithDependentSource<GetPhotosByAccommodationId, PhotoOfAccommodation,
                    IEnumerable<AccommodationPhoto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync()
        {
            //Arrange
            var handler = Handler();
            var dispatcher = new Mock<IProvider>();
            var query = new GetPhotosByAccommodationId(dispatcher.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<AccommodationPhoto>>>(result);
        }

        private static PhotosByAccommodationId Handler()
        {
            var photos = new PhotoOfAccommodation[1].AsQueryable();
            var ownPhotosOfAccommodationsMock = new Mock<IHavePropertyQueryable<PhotoOfAccommodation>>();
            ownPhotosOfAccommodationsMock.Setup(p => p.Queryable).Returns(photos);
            var projectionMock = new Mock<IProjection>();

            return new PhotosByAccommodationId(ownPhotosOfAccommodationsMock.Object,projectionMock.Object);
        }
    }
}