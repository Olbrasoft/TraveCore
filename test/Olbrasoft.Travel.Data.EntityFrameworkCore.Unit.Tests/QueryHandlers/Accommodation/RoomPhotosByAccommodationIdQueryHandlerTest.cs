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
    internal class RoomPhotosByAccommodationIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IPropertyContext_Comma_RoomPhotosByAccommodationIdQuery_Comma_IQueryable_Of_PhotoOfAccommodation_Comma_IEnumerable_Of_RoomPhoto()
        {
            //Arrange
            var type = typeof(TravelQueryHandler<RoomPhotosByRealEstateIdQuery, Photo, IEnumerable<RoomPhotoDto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static RoomPhotosByAccommodationIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new RoomPhotosByAccommodationIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_RoomPhoto()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<RoomPhotoDto>>);
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new RoomPhotosByRealEstateIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}