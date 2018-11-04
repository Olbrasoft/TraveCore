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
    internal class PhotosOfAccommodationsTest
    {
        [Test]
        public void Instance_Is_HandlerWithDependentSource_Of_GetPhotosOfAccommodations_IQueryable_PhotoOfAccommodation_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type =
                typeof(HandlerWithDependentSource<GetPhotosOfAccommodations,
                  PhotoOfAccommodation, IEnumerable<AccommodationPhoto>>);

            //Act
            var handler = CreateHandler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void Handle()
        {
            //Arrange
            var handler = CreateHandler();
            var dispatcher= new Mock<IProvider>();
            var query = new GetPhotosOfAccommodations(dispatcher.Object);

            //Act
            var result = handler.Handle(query);

            //Assert
            Assert.IsInstanceOf<IEnumerable<AccommodationPhoto>>(result);
        }


        [Test]
        public void HandleAsync()
        {
            //Arrange
            var handler = CreateHandler();
            var dispatcher = new Mock<IProvider>();
            var query = new GetPhotosOfAccommodations(dispatcher.Object);

            //Act
            var result = handler.HandleAsync(query);
            
            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<AccommodationPhoto>>>(result);
        }

        private static PhotosOfAccommodations CreateHandler()
        {
            var photos = new PhotoOfAccommodation[1].AsQueryable();
            var ownPhotosOfAccommodationsMock = new Mock<IHavePropertyQueryable<PhotoOfAccommodation>>();


            ownPhotosOfAccommodationsMock.Setup(p => p.Queryable).Returns(photos);
            var projectionMock = new Mock<IProjection>();

            return new PhotosOfAccommodations(ownPhotosOfAccommodationsMock.Object,projectionMock.Object);
        }
    }
}