using System.Collections.Generic;
using System.Threading;
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
    internal class RoomsTest
    {
        [Test]
        public void Instance_Is_AsyncHandlerWithDependentSource()
        {
            //Arrange
            var type =
                typeof(AsyncHandlerWithDependentSource<GetRooms, TypeOfRoom,
                    IEnumerable<Room>>);

            var ownerMock = new Mock<IHavePropertyQueryable<TypeOfRoom>>();
            var projectorMock = new Mock<IProjection>();

            //Act
            var handler = new Rooms(ownerMock.Object, projectorMock.Object);

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync()
        {
            //Arrange
            var ownerMock = new Mock<IHavePropertyQueryable<TypeOfRoom>>();
            var projectorMock = new Mock<IProjection>();

            var handler = new Rooms(ownerMock.Object, projectorMock.Object);

            var providerMock = new Mock<IProvider>();
            var query = new GetRooms(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query, default(CancellationToken));

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<Room>>>(result);
        }
    }
}