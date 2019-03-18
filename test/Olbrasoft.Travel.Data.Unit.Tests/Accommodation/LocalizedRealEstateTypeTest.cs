using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class LocalizedRealEstateTypeTest
    {
        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Some Name";

            //Act
            var localization = new LocalizedRealEstateType
            {
                Name = name
            };

            //Assert
            Assert.AreEqual(name, localization.Name);
        }

        [Test]
        public void Type()
        {
            //Arrange
            var type = new RealEstateType();

            //Act
            var localization = new LocalizedRealEstateType
            {
                Type = type
            };

            //Assert
            Assert.AreSame(type, localization.Type);
        }
    }
}