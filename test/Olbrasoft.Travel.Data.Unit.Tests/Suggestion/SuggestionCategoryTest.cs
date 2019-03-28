using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.Localization;
using Olbrasoft.Travel.Data.Suggestion;

namespace Olbrasoft.Travel.Data.Unit.Tests.Suggestion
{
    public class SuggestionCategoryTest
    {
        [Test]
        public void Instance_Is_HaveName()
        {
            //Arrange
            var type = typeof(OwnerCreatorInfoAndCreator);

            //Act
            var suggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, suggestionType);
        }

        private static SuggestionCategory Create()
        {
            var suggestionType = new SuggestionCategory();
            return suggestionType;
        }

        [Test]
        public void Instance_Implement_Interface_IHaveAscending()
        {
            //Arrange
            var type = typeof(IHaveAscending);

            //Act
            var suggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, suggestionType);
        }

        [Test]
        public void Ascending()
        {
            //Arrange
            const int asc = 1976;
            var type = Create();

            //Act
            type.Ascending = asc;

            //Assert
            Assert.AreEqual(asc, type.Ascending);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveLocalizedTypes_Of_SuggestionType()
        {
            //Arrange
            var type = typeof(IHaveLocalizedTypes<LocalizedSuggestionCategory>);

            //Act
            var suggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, suggestionType);
        }

        [Test]
        public void LocalizedTypes()
        {
            //Arrange
            var suggestionTypeLocalizedTypes = new List<LocalizedSuggestionCategory>();

            var suggestionType = Create();

            //Act
            suggestionType.LocalizedSuggestionCategories = suggestionTypeLocalizedTypes;

            //Assert
            Assert.AreSame(suggestionTypeLocalizedTypes, suggestionType.LocalizedSuggestionCategories);
        }

        [Test]
        public void RegionSubtypes()
        {
            //Arrange
            var subtypes = (ICollection<RegionSubtype>)new List<RegionSubtype>();
            var suggestionType = Create();

            //Act
            suggestionType.RegionSubtypes = subtypes;

            //Assert
            Assert.AreSame(subtypes, suggestionType.RegionSubtypes);
        }

        [Test]
        public void RealEstateTypes()
        {
            //Arrange
            var realEstateTypes = (ICollection<RealEstateCategory>)new List<RealEstateCategory>();
            var suggestionType = Create();

            //Act
            suggestionType.RealEstateTypes = realEstateTypes;

            //Assert
            Assert.AreSame(realEstateTypes, suggestionType.RealEstateTypes);
        }
    }
}