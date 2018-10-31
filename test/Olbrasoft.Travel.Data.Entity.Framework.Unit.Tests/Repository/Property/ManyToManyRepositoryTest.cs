using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Property;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Property
{
    [TestFixture]
    internal class ManyToManyRepositoryTest
    {
        [Test]
        public void Instance_Is_OfManyToMany_Of_ManyToMany()
        {
            //Arrange
            var type = typeof(OfManyToMany<ManyToMany>);

            //Act
            var repository = ManyToManyRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        [Test]
        public void Instance_Implement_Interface_IManyToManyRepository_Of_ManyToMany()
        {
            //Arrange
            var type = typeof(Data.Repository.Property.IManyToManyRepository<ManyToMany>);

            //Act
            var repository = ManyToManyRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        private static ManyToManyRepository<ManyToMany> ManyToManyRepository()
        {
            var contextMock = new Mock<PropertyDatabaseContext>();

            var repository = new ManyToManyRepository<ManyToMany>(contextMock.Object);

            return repository;
        }
    }
}