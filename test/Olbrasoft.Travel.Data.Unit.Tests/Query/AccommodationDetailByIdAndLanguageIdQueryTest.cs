using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Unit.Tests.Query
{
    [TestFixture]
    internal class AccommodationDetailByIdAndLanguageIdQueryTest
    {
        [Test]
        public void Instance_Is_ByLanguageIdQuery_Of_AccommodationDetail()
        {
            //Arrange
            var type = typeof(ByLanguageIdQuery<AccommodationDetail>);
            var providerMock = new Mock<IProvider>();

            //Act
            var query = new AccommodationDetailByIdAndLanguageIdQuery(providerMock.Object);

            //Assert
            Assert.IsInstanceOf(type, query);
        }

        [Test]
        public void Instance_Implement_Interface_IQueryOfAccommodationDetail()
        {
            //Arrange
            var dispatcherMock = new Mock<IProvider>();

            //Act
            var query = new AccommodationDetailByIdAndLanguageIdQuery(dispatcherMock.Object);

            //Assert
            Assert.IsInstanceOf<IQuery<AccommodationDetail>>(query);
        }

        [Test]
        public void LanguageId()
        {
            //Arrange
            var dispatcherMock = new Mock<IProvider>();
            var query = new AccommodationDetailByIdAndLanguageIdQuery(dispatcherMock.Object)
            {
                LanguageId = 1033,
            };

            //Act
            var result = query.LanguageId;

            //Assert
            Assert.IsTrue(result == 1033);
        }

        [Test]
        public void Id()
        {
            //Arrange
            var dispatcherMock = new Mock<IProvider>();
            var query = new AccommodationDetailByIdAndLanguageIdQuery(dispatcherMock.Object)
            {
                Id = 42,
            };

            //Act
            var result = query.Id;

            //Assert
            Assert.IsTrue(result == 42);
        }
    }
}