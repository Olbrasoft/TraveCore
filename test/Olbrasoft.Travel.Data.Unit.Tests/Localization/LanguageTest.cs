using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Unit.Tests.Localization
{
    [TestFixture]
    internal class LanguageTest
    {
        [Test]
        public void Instance_Implement_Interface_IHaveId_Of_Integer()
        {
            //Arrange
            var type = typeof(IHaveId<int>);

            //Act
            var language = new Language();

            //Assert
            Assert.IsInstanceOf(type, language);
        }

        [Test]
        public void Instance_Implement_Interface_ICreatorInfo_Of_Integer()
        {
            //Arrange
            var type = typeof(IHaveCreatorId<int>);

            //Act
            var language = new Language();

            //Assert
            Assert.IsInstanceOf(type, language);
        }

        [Test]
        public void ExpediaCode()
        {
            //Arrange
            const string code = "Cs_Cz";

            //Act
            var lang = new Language
            {
                ExpediaCode = code
            };

            //Assert
            Assert.AreEqual(code, lang.ExpediaCode);
        }

        [Test]
        public void PropertyTypesTranslations()
        {
            //Arrange
            var localizations = new List<PropertyTypeTranslation>();

            //Act

            var lang = new Language
            {
                PropertyTypesTranslations = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.PropertyTypesTranslations);
        }

        [Test]
        public void PropertiesTranslations()
        {
            //Arrange
            var localizations = new List<PropertyTranslation>();

            //Act

            var lang = new Language
            {
                PropertiesTranslations = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.PropertiesTranslations);
        }

        [Test]
        public void LocalizedRoomTypes()
        {
            //Arrange
            var localizations = new List<RoomTranslation>();

            //Act

            var lang = new Language
            {
                RoomsTranslations = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.RoomsTranslations);
        }

        [Test]
        public void PropertiesToAttributes()
        {
            //Arrange
            var localizations = new List<PropertyToAttribute>();

            //Act

            var lang = new Language
            {
                PropertiesToAttributes = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.PropertiesToAttributes);
        }
    }
}