using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repositories.Accommodation
{
    [TestFixture]
    internal class ManyToManyRepositoryTest
    {
        [Test]
        public void Instance_Is_OfManyToMany_Of_ManyToMany()
        {
            //Arrange
            var type = typeof(ManyToManyRepository<ManyToMany>);

            //Act
            var repository = ManyToManyRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        [Test]
        public void Instance_Implement_Interface_IManyToManyRepository_Of_ManyToMany()
        {
            //Arrange
            var type = typeof(IManyToManyRepository<ManyToMany>);

            //Act
            var repository = ManyToManyRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        private static ManyToManyRepository<ManyToMany> ManyToManyRepository()
        {
            var contextMock = new Mock<TravelDbContext>();

            var repository = new ManyToManyRepository<ManyToMany>(contextMock.Object);

            return repository;
        }
    }
}