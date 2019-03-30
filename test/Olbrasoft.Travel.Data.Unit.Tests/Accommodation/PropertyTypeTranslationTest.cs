using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class PropertyTypeTranslationTest
    {
        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Some Name";

            //Act
            var localization = new PropertyTypeTranslation
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
            var type = new PropertyType();

            //Act
            var localization = new PropertyTypeTranslation
            {
                PropertyType = type
            };

            //Assert
            Assert.AreSame(type, localization.PropertyType);
        }
    }
}