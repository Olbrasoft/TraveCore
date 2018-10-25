using Moq;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Framework.Repository;
using Olbrasoft.Travel.Data.Entity.Framework.Repository.Identity;
using Olbrasoft.Travel.Data.Entity.Identity;
using Olbrasoft.Travel.Data.Repository;

namespace Olbrasoft.Travel.Data.Entity.Framework.Unit.Tests.Repository.Identity
{
    [TestFixture]
    internal class UsersRepositoryTest
    {
        [Test]
        public void Instance_Is_BaseRepository_Of_User()
        {
            //Arrange
            var type = typeof(BaseRepository<User>);

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
            var type = typeof(IdentityRepository<User>);

            //Act
            var repository = CreateRepository();


            //Assert
            Assert.IsInstanceOf(type, repository);

        }

        private static UsersRepository CreateRepository()
        {
            var dboContextMock = new Mock<IdentityDatabaseContext>();

            var repository = new UsersRepository(dboContextMock.Object);
            return repository;
        }
    }
}