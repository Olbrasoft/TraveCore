using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Identity
{
    [TestFixture]
    internal class UserTokenConfigurationTest
    {
        [Test]
        public void Instance_Is_IdentityConfiguration_Of_UserToken()
        {
            //Arrange
            var type = typeof(IdentityConfiguration<UserToken>);

            //Act
            var configuration= new UserTokenConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);
        }
    }
}