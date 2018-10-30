using NUnit.Framework;
using Olbrasoft.Travel.Data.Entity.Configuration.Globalization;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Unit.Tests.Globalization
{
    [TestFixture]
    internal class LocalizedDescriptionOfAccommodationConfigurationTest
    {
        [Test]
        public void Instance_Is_PropertyConfiguration_Of_Description()
        {
            //Arrange
            var type = typeof(GlobalizationConfiguration<LocalizedDescriptionOfAccommodation>);

            //Act
            var configuration = new LocalizedDescriptionOfAccommodationConfiguration();

            //Assert
            Assert.IsInstanceOf(type, configuration);
        }
    }
}