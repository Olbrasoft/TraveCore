using NUnit.Framework;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Identity
{
    [TestFixture]
    internal class RoleClaimConfigurationTest
    {

        [Test]
        public void Instance_Is_IdentityConfiguration_Of_RoleClaim()
        {
            //Arrange
            var type = typeof(IdentityConfiguration<RoleClaim>);

            //Act
            var configuration = new RoleClaimConfiguration();

            //Assert
            Assert.IsInstanceOf(type,configuration);
        }

    }
}