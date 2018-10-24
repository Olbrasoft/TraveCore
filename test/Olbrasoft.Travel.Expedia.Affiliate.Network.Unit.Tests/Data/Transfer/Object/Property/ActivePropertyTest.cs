using NUnit.Framework;
using Olbrasoft.Travel.Expedia.Affiliate.Network.Data.Transfer.Object.Property;

namespace Olbrasoft.Travel.Expedia.Affiliate.Network.Unit.Tests.Data.Transfer.Object.Property
{
    [TestFixture]
    internal class ActivePropertyTest
    {
        [Test]
        public void Instance_Implement_Interface_IToLocalizedAccommodation()
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