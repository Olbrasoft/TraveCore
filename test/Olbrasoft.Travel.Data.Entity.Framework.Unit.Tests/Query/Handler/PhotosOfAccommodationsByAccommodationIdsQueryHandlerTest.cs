using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Property;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class PhotosOfAccommodationsByAccommodationIdsQueryHandlerTest
    {
        [Test]
        public void Inherits_From_TravelQueryHandler_Of_IPropertyContext_Comma_PhotosOfAccommodationsByAccommodationIdsQuery_Comma_IQueryable_Of_PhotoOfAccommodation_Comma_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(TravelQueryHandler<IPropertyContext, PhotosOfAccommodationsByAccommodationIdsQuery,
                IQueryable<PhotoOfAccommodation>, IEnumerable<AccommodationPhoto>>);

            //Act
            var handler = Handler();

            //Assert
            Assert.IsInstanceOf(type,handler);
        }

        private static PhotosOfAccommodationsByAccommodationIdsQueryHandler Handler()
        {
            var contextMock = new Mock<IPropertyContext>();
            var projectorMock = new Mock<IProjection>();

            var handler = new PhotosOfAccommodationsByAccommodationIdsQueryHandler(contextMock.Object, projectorMock.Object);
            return handler;
        }

        [Test]
        public void HandleAsync_Return_Task_Of_IEnumerable_Of_AccommodationPhoto()
        {
            //Arrange
            var type = typeof(Task<IEnumerable<AccommodationPhoto>>);
            var handler = Handler();
            var providerMock = new Mock<IProvider>();
            var query = new PhotosOfAccommodationsByAccommodationIdsQuery(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query);

            //Assert
            Assert.IsInstanceOf(type,result);

        }

    }
}