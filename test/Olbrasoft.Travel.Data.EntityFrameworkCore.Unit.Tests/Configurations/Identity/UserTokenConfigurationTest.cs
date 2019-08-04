using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Identity;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Identity;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Identity
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