using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class DescriptionTranslationTest
    {
        [Test]
        public void Instance_Is_Translation()
        {
            //Arrange
            var type = typeof(Translation);

            //Act
            var translation = new DescriptionTranslation();

            //Assert
            Assert.IsInstanceOf(type, translation);
        }

        [Test]
        public void PropertyId()
        {
            //Arrange
            const int id = 1976;

            //Act
            var localization = new DescriptionTranslation
            {
                PropertyId = id
            };

            //Assert
            Assert.AreEqual(id, localization.PropertyId);
        }
    }
}