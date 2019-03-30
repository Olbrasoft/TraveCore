using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class PropertyTypeTest
    {
        [Test]
        public void LocalizedPropertyTypes()
        {
            //Arrange
            var localizedRealEstateTypes = new[] { new PropertyTypeTranslation() };

            //Act
            var realEstateType = new PropertyType
            {
                PropertyTypesTranslations = localizedRealEstateTypes
            };

            //Assert
            Assert.AreSame(localizedRealEstateTypes, realEstateType.PropertyTypesTranslations);
        }

        [Test]
        public void SuggestionTypeId()
        {
            //Arrange
            const int suggestionTypeId = 1976;

            //Act
            var realEstateType = new PropertyType
            {
                SuggestionCategoryId = suggestionTypeId
            };

            //Assert
            Assert.AreEqual(suggestionTypeId, realEstateType.SuggestionCategoryId);
        }
    }
}