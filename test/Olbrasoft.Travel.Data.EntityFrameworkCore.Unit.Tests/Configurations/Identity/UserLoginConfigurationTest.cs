using NUnit.Framework;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations;
using Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Identity;
using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Unit.Tests.Configurations.Identity
{
    [TestFixture]
    public class UserLoginConfigurationTest
    {
        [Test]
        public void Instance_Is_TravelTypeConfiguration_Of_UserLogin()
        {
            //Arrange
            var type = typeof(TravelTypeConfiguration<UserLogin>);

            //Act
            var configuration = new UserLoginConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }

        //[Test]
        //public void Configuration()
        //{
        //    //Arrange
        //    var configuration = new UserLoginConfiguration();

        //    var builderMock = new Mock<EntityTypeBuilder<UserLogin>>();
        //    var keyBuilderMock = new Mock<KeyBuilder>();
        //    builderMock.Setup(p => p.HasKey()).Returns(keyBuilderMock.Object);

        //    //Act
        //    configuration.Configuration(builderMock.Object);

        //    //Assert

        //}
    }
}