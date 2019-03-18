using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Identity;
using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Identity
{
    [TestFixture]
    public class UserTokenConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelConfiguration_Of_UserLogin()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<UserToken>);

            //Act
            var configuration = new UserTokenConfiguration();
            //Assert

            Assert.IsInstanceOf(type, configuration);
        }
    }
}