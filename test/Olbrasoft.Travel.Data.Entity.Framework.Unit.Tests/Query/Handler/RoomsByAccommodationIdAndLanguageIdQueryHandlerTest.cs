using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olbrasoft.Data.Queries;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class RoomsByAccommodationIdAndLanguageIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IPropertyContext_Comma_RoomsByAccommodationIdAndLanguageIdQuery_Comma_IQueryable_Of_TypeOfRoom_Comma_IEnumerable_Of_Room()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<IPropertyContext, RoomsByAccommodationIdAndLanguageIdQuery, IQueryable<TypeOfRoom>, IEnumerable<Room>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static RoomsByAccommodationIdAndLanguageIdQueryHandler Handler()
        {
            var contextMock = new Mock<IPropertyContext>();
            var projector = new Mock<IProjection>();

            var handler = new RoomsByAccommodationIdAndLanguageIdQueryHandler(contextMock.Object, projector.Object);
            return handler;
        }


        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_Room()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<Room>>);
            var handler = Handler();
            var providerMock = new Mock<IProvider>();
            var query = new RoomsByAccommodationIdAndLanguageIdQuery(providerMock.Object);
            
            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type,result);

        }
    }
}