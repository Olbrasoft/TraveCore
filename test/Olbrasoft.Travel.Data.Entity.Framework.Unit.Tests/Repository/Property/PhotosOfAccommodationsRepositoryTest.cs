using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Property
{
    [TestFixture]
    internal class PhotosOfAccommodationsRepositoryTest
    {
        [Test]
        public void Instance_Is_PropertyRepository_Of_PhotoOfAccommodation()
        {
            //Arrange
            var type = typeof(PropertyRepository<PhotoOfAccommodation>);
            var contextMock = new Mock<PropertyDatabaseContext>();

            //Act
            var repository = new PhotosOfAccommodationsRepository(contextMock.Object);

            //Assert
            Assert.IsInstanceOf(type, repository);
        }
    }
}