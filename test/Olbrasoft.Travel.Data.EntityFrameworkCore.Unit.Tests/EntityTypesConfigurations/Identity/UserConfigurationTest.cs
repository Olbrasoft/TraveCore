using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Identity;
using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.EntityTypesConfigurations.Identity
{
    [TestFixture]
    internal class UserConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_User()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<User>);

            //Act
            var configuration = new UserConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);
        }
    }
}