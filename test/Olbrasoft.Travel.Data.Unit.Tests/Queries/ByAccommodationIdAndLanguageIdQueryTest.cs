using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Queries;

namespace Olbrasoft.Travel.Data.Unit.Tests.Queries
{
    [TestFixture]
    internal class ByAccommodationIdAndLanguageIdQueryTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveAccommodationId()
        {
            //Arrange
            var type = typeof(IHaveAccommodationId);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void ExampleByAccommodationIdAndLanguageIdQuery_Inherits_From_ByAccommodationIdAndLanguageIdQuery_Of_object()
        {
            //Arrange
            var type = typeof(ByAccommodationIdAndLanguageIdQuery<object>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        private static ExampleByAccommodationIdAndLanguageIdQuery Query()
        {
            var providerMock = new Mock<IProvider>();
            return new ExampleByAccommodationIdAndLanguageIdQuery(providerMock.Object);
        }

        [Test]
        public void Inherits_From_ByLanguageIdQuery()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<object>);

            //Act
            var query = Query();

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void AccommodationId_Get_Set()
        {
            //Arrange
            const int accommodationId = int.MaxValue;
            var query = Query();

            //Act
            query.AccommodationId = accommodationId;

            //Assert
            Assert.IsTrue(query.AccommodationId == accommodationId);
        }
    }
}