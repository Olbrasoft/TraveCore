using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Identity;
using Olbrasoft.Travel.Data.Entity.Identity;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Identity
{
    [TestFixture]
    internal class UserConfigurationTest
    {
        [Test]
        public void Instance_Is_IdentityConfiguration_Of_User()
        {
            //Arrange
            var type = typeof(IdentityConfiguration<User>);

            //Act
            var configuration = new UserConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);
        }
    }
}