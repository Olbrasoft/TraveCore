using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class PhotosByAccommodationIdQueryHandlerTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type =
                typeof(TravelQueryHandler<IPropertyContext, PhotosByAccommodationIdQuery,
                    IQueryable<PhotoOfAccommodation>, IEnumerable<AccommodationPhoto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<AccommodationPhoto>>);
            var handler = Handler();
            var providerMock = new Mock<IProvider>();

            var query = new PhotosByAccommodationIdQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type, result);
        }

        private static PhotosByAccommodationIdQueryHandler Handler()
        {
            var contextMock = new Mock<IPropertyContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PhotosByAccommodationIdQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }
    }
}