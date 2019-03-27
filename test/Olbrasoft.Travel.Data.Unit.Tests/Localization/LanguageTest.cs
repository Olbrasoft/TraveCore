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
        public void LocalizedRealEstateTypes()
        {
            //Arrange
            var localizations = new List<LocalizedRealEstateCategory>();

            //Act
           
            var lang = new Language
            {
               LocalizedRealEstateTypes = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.LocalizedRealEstateTypes);

        }


        [Test]
        public void LocalizedRealEstates()
        {
            //Arrange
            var localizations = new List<LocalizedRealEstate>();

            //Act

            var lang = new Language
            {
                LocalizedRealEstates = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.LocalizedRealEstates);

        }


        [Test]
        public void LocalizedDescriptions()
        {
            //Arrange
            var localizations = new List<LocalizedDescription>();

            //Act

            var lang = new Language
            {
                LocalizedDescriptions = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.LocalizedDescriptions);

        }

        [Test]
        public void LocalizedRoomTypes()
        {
            //Arrange
            var localizations = new List<LocalizedRoom>();

            //Act

            var lang = new Language
            {
                LocalizedRoomTypes = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.LocalizedRoomTypes);

        }


        [Test]
        public void RealEstatesToAttributes()
        {
            //Arrange
            var localizations = new List<RealEstateToAttribute>();

            //Act

            var lang = new Language
            {
               RealEstatesToAttributes = localizations
            };

            //Assert
            Assert.AreSame(localizations, lang.RealEstatesToAttributes);

        }


    }
}