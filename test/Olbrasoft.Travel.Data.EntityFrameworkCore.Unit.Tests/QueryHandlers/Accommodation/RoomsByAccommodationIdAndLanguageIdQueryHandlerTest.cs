using Moq;
using NUnit.Framework;
using Olbrasoft.Mapping;
using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Room = Olbrasoft.Travel.Data.Base.Objects.Accommodation.Room;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers.Accommodation
{
    [TestFixture]
    internal class RoomsByAccommodationIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IPropertyContext_Comma_RoomsByAccommodationIdAndLanguageIdQuery_Comma_IQueryable_Of_TypeOfRoom_Comma_IEnumerable_Of_Room()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<RoomsByPropertyIdAndLanguageIdQuery, IEnumerable<Transfer.Objects.Accommodation.RoomDto>, Room>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static RoomsByPropertyIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projector = new Mock<IProjection>();

            var handler = new RoomsByPropertyIdAndLanguageIdQueryHandler(projector.Object, contextMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_Room()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<Transfer.Objects.Accommodation.RoomDto>>);
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new RoomsByPropertyIdAndLanguageIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}