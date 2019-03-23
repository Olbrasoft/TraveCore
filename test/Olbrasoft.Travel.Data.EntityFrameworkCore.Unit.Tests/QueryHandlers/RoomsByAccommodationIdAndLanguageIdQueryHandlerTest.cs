using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Room = Olbrasoft.Travel.Data.Accommodation.Room;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.QueryHandlers
{
    [TestFixture]
    internal class RoomsByAccommodationIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IPropertyContext_Comma_RoomsByAccommodationIdAndLanguageIdQuery_Comma_IQueryable_Of_TypeOfRoom_Comma_IEnumerable_Of_Room()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<RoomsByRealEstateIdAndLanguageIdQuery, Room, IEnumerable<Transfer.Objects.Room>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static RoomsByAccommodationIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<TravelDbContext>();
            var projector = new Mock<IProjection>();

            var handler = new RoomsByAccommodationIdAndLanguageIdQueryHandler(contextMock.Object, projector.Object);
            return handler;
        }


        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_Room()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<Transfer.Objects.Room>>);
            var handler = Handler();
            var providerMock = new Mock<IQueryDispatcher>();
            var query = new RoomsByRealEstateIdAndLanguageIdQuery(providerMock.Object);
            
            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type,result);

        }
    }
}