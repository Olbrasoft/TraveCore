using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
    internal class RoomPhotosByAccommodationIdQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IPropertyContext_Comma_RoomPhotosByAccommodationIdQuery_Comma_IQueryable_Of_PhotoOfAccommodation_Comma_IEnumerable_Of_RoomPhoto()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<IPropertyContext, RoomPhotosByAccommodationIdQuery,
                    IQueryable<PhotoOfAccommodation>, IEnumerable<RoomPhoto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        private static RoomPhotosByAccommodationIdQueryHandler Handler()
        {
            var contextMock = new Mock<IPropertyContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new RoomPhotosByAccommodationIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_RoomPhoto()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<RoomPhoto>>);
            var handler = Handler();
            var providerMock = new Mock<IProvider>();
            var query = new RoomPhotosByAccommodationIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }
    }
}