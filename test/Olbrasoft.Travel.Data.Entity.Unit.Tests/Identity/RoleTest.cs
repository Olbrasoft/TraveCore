using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Identity;

namespace Olbrasoft.Travel.Data.Entity.Unit.Tests.Identity
{
    [TestFixture]
    internal class RoleTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveDateTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateTimeOfCreation);

            //Act
            var role = new Role();
            
            //Assert
            Assert.IsInstanceOf(type,role);
        }

        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type = typeof(Microsoft.AspNetCore.Identity.IdentityRole<int>);

            //Act
            var role = new Role();

            //Assert
            Assert.IsInstanceOf(type,role);
        }

    }
}