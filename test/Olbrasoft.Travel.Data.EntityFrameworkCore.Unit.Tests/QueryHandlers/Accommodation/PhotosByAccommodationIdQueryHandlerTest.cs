using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Accommodation
{
    [TestFixture]
    internal class PhotosByAccommodationIdQueryHandlerTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type = typeof(TravelQueryHandler<PhotosByRealEstateIdQuery, Photo, IEnumerable<PropertyPhotoDto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<PropertyPhotoDto>>);
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();

            var query = new PhotosByRealEstateIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static PhotosByAccommodationIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PhotosByAccommodationIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
}