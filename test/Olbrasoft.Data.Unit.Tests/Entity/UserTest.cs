using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Data.Unit.Tests.Entity
{
    [TestFixture]
    internal class UserTest
    {
        [Test]
        public void Instance_Implement_Interface_ICreation()
        {
            //Arrange
            var type = typeof(IHaveId<int>);

            //Act
            var user = new User<int>();

            //Assert
            Assert.IsInstanceOf(type, user);
        }

        [Test]
        public void UserName()
        {
            //Arrange
            var user = new User<int>()
            {
                UserName = "Jirka"
            };

            //Act
            var userName = user.UserName;

            //Assert
            Assert.IsTrue(userName == "Jirka");
        }
    }
}