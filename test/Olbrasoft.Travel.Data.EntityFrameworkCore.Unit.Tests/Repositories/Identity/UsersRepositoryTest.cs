using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories;
using Olbrasoft.Travel.Data.Identity;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Repositories.Identity
{
    [TestFixture]
    internal class UsersRepositoryTest
    {
        [Test]
        public void Instance_Is_BaseRepository_Of_User()
        {
            //Arrange
            var type = typeof(TravelRepository<User>);

            //act
            var repository = CreateRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        [Test]
        public void Instance_Implement_Interface_IUsersRepository()
        {
            //Arrange
            var type = typeof(IUsersRepository);

            //Act
            var repository = CreateRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }  

        [Test]
        public void Instance_Is_IdentityRepository_Of_User()
        {
            //Arrange
            var type = typeof(TravelRepository<User>);

            //Act
            var repository = CreateRepository();

            //Assert
            Assert.IsInstanceOf(type, repository);
        }

        private static UsersRepository CreateRepository()
        {
            var dboContextMock = new Mock<TravelDbContext>();

            var repository = new UsersRepository(dboContextMock.Object);
            return repository;
        }
    }
}