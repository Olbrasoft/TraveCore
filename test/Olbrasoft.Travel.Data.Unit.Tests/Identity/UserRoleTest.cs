using NUnit.Framework;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.Unit.Tests.Identity
{
    [TestFixture]
    public class UserRoleTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveDateTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateAndTimeOfCreation);

            //Act
            var userRole = UserRole();

            //Assert
            Assert.IsInstanceOf(type, userRole);
        }

        private static UserRole UserRole()
        {
            var userRole = new UserRole();
            return userRole;
        }

        [Test]
        public void Instance_Is_IdentityUserRole_Of_Integer()
        {
            //Arrange
            var type = typeof(Microsoft.AspNetCore.Identity.IdentityUserRole<int>);

            //Act
            var userRole = UserRole();

            //Assert
            Assert.IsInstanceOf(type, userRole);
        }
    }
}