using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Framework.Query.Handler;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Query;
using Attribute = Olbrasoft.Travel.Data.Transfer.Object.Attribute;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Query.Handler
{
    [TestFixture]
    internal class AttributesByAccommodationIdAndLanguageIdTest
    {
        [Test]
        public void Instance_Implement_Interface_IHandler_Of_IEnumerable_Of_Attribute()
        {
            //Arrange
            var type = typeof(IHandler<GetAttributesByAccommodationIdAndLanguageId, IEnumerable<Attribute>>);
            var ownerMock = new Mock<IHaveGlobalizationQueryable<AccommodationToAttribute>>();
            var projectorMock = new Mock<IProjection>();

            //Act
            var handler = new AttributesByAccommodationIdAndLanguageId(ownerMock.Object, projectorMock.Object);

            //Assert
            Assert.IsInstanceOf(type, handler);
        }

        [Test]
        public void HandleAsync()
        {
            //Arrange
            var ownerMock = new Mock<IHaveGlobalizationQueryable<AccommodationToAttribute>>();
            var projectorMock = new Mock<IProjection>();

            var handler = new AttributesByAccommodationIdAndLanguageId(ownerMock.Object, projectorMock.Object);

            var providerMock = new Mock<IProvider>();
            var query = new GetAttributesByAccommodationIdAndLanguageId(providerMock.Object);

            //Act
            var result = handler.HandleAsync(query, default(CancellationToken));

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<Attribute>>>(result);
        }
    }
}