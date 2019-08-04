using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Identity;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Identity;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Identity
{
    [TestFixture]
    public class UserRoleConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_UserLogin()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<UserRole>);

            //Act
            var configuration = new UserRoleConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}