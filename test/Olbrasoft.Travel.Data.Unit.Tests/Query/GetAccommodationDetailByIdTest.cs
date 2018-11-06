using Moq;
using NUnit.Framework;
using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Unit.Tests.Query
{
    [TestFixture]
    internal class GetAccommodationDetailByIdTest
    {
        [Test]
        public void Instance_Implement_Interface_IQueryOfAccommodationDetail()
        {
            //Arrange
            var dispatcherMock = new Mock<IProvider>();

            //Act
            var query = new GetAccommodationDetailById(dispatcherMock.Object);

            //Assert
            Assert.IsInstanceOf<IQuery<AccommodationDetail>>(query);
        }

        [Test]
        public void LanguageId()
        {
            //Arrange
            var dispatcherMock = new Mock<IProvider>();
            var query = new GetAccommodationDetailById(dispatcherMock.Object)
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
            var query = new GetAccommodationDetailById(dispatcherMock.Object)
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