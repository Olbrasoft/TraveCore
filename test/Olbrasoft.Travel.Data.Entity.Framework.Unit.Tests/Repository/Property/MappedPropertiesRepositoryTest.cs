using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Property;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Property
{
    [TestFixture]
    internal class MappedPropertiesRepositoryTest
    {
        [Test]
        public void Instance_Is_PropertyRepository_Of_TypeOfAccommodation()
        {
            //Arrange
            var type = typeof(PropertyRepository<TypeOfAccommodation>);
            var contextMock = new Mock<PropertyDatabaseContext>();

            //Act
            var repository= new MappedPropertiesRepository<TypeOfAccommodation>(contextMock.Object);

            //Assert
            Assert.IsInstanceOf(type,repository);

        }
    }
}