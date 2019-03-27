using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Suggestion;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class RealEstateCategoryTest
    {
        [Test]
        public void LocalizedPropertyTypes()
        {
            //Arrange
            var localizedRealEstateTypes = new[] { new LocalizedRealEstateCategory() };

            //Act
            var realEstateType = new RealEstateCategory
            {
                LocalizedRealEstateTypes = localizedRealEstateTypes
            };

            //Assert
            Assert.AreSame(localizedRealEstateTypes, realEstateType.LocalizedRealEstateTypes);
        }

        [Test]
        public void SuggestionTypeId()
        {
            //Arrange
            const int suggestionTypeId = 1976;

            //Act
            var realEstateType = new RealEstateCategory
            {
                SuggestionCategoryId = suggestionTypeId
            };

            //Assert
            Assert.AreEqual(suggestionTypeId, realEstateType.SuggestionCategoryId);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveSuggestionType()
        {
            //Arrange
            var type = typeof(IHaveSuggestionCategory);

            //Act
            var realEstateType = new RealEstateCategory();

            //Assert
            Assert.IsInstanceOf(type, realEstateType);
        }

        [Test]
        public void RealEstateType()
        {
            //Arrange
            var suggestionType = new SuggestionCategory();

            //Act
            var realEstateType = new RealEstateCategory()
            {
                SuggestionCategory = suggestionType
            };

            //Assert
            Assert.AreSame(suggestionType, realEstateType.SuggestionCategory);
        }
    }
}