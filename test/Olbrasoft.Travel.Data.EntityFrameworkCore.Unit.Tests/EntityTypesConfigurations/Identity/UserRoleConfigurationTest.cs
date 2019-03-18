using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Identity;
using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Identity
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