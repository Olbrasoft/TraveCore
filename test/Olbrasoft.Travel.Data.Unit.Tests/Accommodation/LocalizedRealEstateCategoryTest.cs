using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class LocalizedRealEstateCategoryTest
    {
        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Some Name";

            //Act
            var localization = new LocalizedRealEstateCategory
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
            var type = new RealEstateCategory();

            //Act
            var localization = new LocalizedRealEstateCategory
            {
                Category = type
            };

            //Assert
            Assert.AreSame(type, localization.Category);
        }
    }
}