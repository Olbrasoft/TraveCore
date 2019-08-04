using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Base.Objects.Identity;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Identity
{
    [TestFixture]
    internal class RoleTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveDateTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateAndTimeOfCreation);

            //Act
            var role = new Role();
            
            //Assert
            Assert.IsInstanceOf(type,role);
        }

        [Test]
        public void Instance_Is_IdentityRole_Of_Integer()
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