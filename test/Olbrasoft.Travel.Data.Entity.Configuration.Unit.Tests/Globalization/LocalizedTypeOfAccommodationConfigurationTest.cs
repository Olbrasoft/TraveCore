using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Globalization
{
    [TestFixture]
    internal class LocalizedTypeOfAccommodationConfigurationTest
    {
        [Test]
        public void Instance_Is_LocalizedConfiguration_Of_LocalizedTypeOfAccommodation()
        {
            //Arrange
            var type = typeof(LocalizedConfiguration<LocalizedTypeOfAccommodation>);

            //Act
            var configuration = new LocalizedTypeOfAccommodationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}