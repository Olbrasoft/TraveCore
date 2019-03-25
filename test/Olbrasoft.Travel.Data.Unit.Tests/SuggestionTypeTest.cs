using NUnit.Framework;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Localization;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    public class SuggestionTypeTest
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

        private static SuggestionType Create()
        {
            var suggestionType = new SuggestionType();
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
            var type = typeof(IHaveLocalizedTypes<LocalizedSuggestionType>);

            //Act
            var suggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, suggestionType);
        }

        [Test]
        public void LocalizedTypes()
        {
            //Arrange
            var suggestionTypeLocalizedTypes = new List<LocalizedSuggestionType>();

            var suggestionType = Create();

            //Act
            suggestionType.LocalizedTypes = suggestionTypeLocalizedTypes;

            //Assert
            Assert.AreSame(suggestionTypeLocalizedTypes, suggestionType.LocalizedTypes);
        }
    }
}