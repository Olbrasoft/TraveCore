using NUnit.Framework;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer;
using Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Property;

namespace Olbrasoft.Travel.Providers.Expedia.Unit.Tests.DataTransfer.Objects.Property
{
    [TestFixture]
    public class ActivePropertyTest
    {
        [Test]
        public void MyTestMethod()
        {
            //Arrange
            var type = typeof(IToLocalizedAccommodation);

            //Act
            var activeProperty = new ActiveProperty();
            
            //Assert
            Assert.IsInstanceOf(type, activeProperty);

        }

    }
}