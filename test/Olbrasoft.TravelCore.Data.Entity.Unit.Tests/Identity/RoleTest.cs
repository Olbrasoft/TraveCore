using NUnit.Framework;
using Olbrasoft.TravelCore.Data.Entity.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Unit.Tests.Identity
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