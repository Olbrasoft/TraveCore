using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Olbrasoft.TravelCore.Data.Entity.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Unit.Tests.Identity
{
    [TestFixture]
    internal class UserTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveDateTimeOfCreation()
        {
            //Arrange
            var type = typeof(IHaveDateTimeOfCreation);

            //Act
            var user= new User();

            //Assert
            Assert.IsInstanceOf(type,user);

        }

        [Test]
        public void Instance_Is_IdentityUser_Of_Integer()
        {
            //Arrange
            var type = typeof(IdentityUser<int>);

            //Act
            var user= new User();

            //Assert
            Assert.IsInstanceOf(type,user);
        }
    }
}