using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Localization;

namespace Olbrasoft.Travel.Data.Unit.Tests.Localization
{
    [TestFixture]
    public class localizedSuggestionTypeTest
    {
        [Test]
        public void Instance_Is_Localized()
        {
            //Arrange
            var type = typeof(Localized);

            //Act
            var localizedSuggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, localizedSuggestionType);
        }

        private static LocalizedSuggestionType Create()
        {
            var localizedSuggestionType = new LocalizedSuggestionType();
            return localizedSuggestionType;
        }

        [Test]
        public void Instance_Implement_Interface_IHaveLabel()
        {
            //Arrange
            var type = typeof(IHaveLabel);

            //Act
            var localizedSuggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, localizedSuggestionType);
        }

        [Test]
        public void Label()
        {
            //Arrange
            const string label = "Awesome label";
            var localizedSuggestionType = Create();

            //Act
            localizedSuggestionType.Label = label;

            //Assert
            Assert.AreEqual(label, localizedSuggestionType.Label);
        }

        [Test]
        public void Instance_Implement_Interface_IHaveType_Of_SuggestionType()
        {
            //Arrange
            var type = typeof(IHaveType<SuggestionType>);

            //Act
            var localizedSuggestionType = Create();

            //Assert
            Assert.IsInstanceOf(type, localizedSuggestionType);
        }

        [Test]
        public void Type()
        {
            //Arrange
            var type = new SuggestionType();
            var localizedSuggestionType = Create();

            //Act
            localizedSuggestionType.Type = type;

            //Assert
            Assert.AreSame(type, localizedSuggestionType.Type);
        }
    }
}