using AutoMapper;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Mapping.LocalizedAccommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Mapping.Profiles.LocalizedAccommodation
{
    [TestFixture]
    public class ToSuggestionTest
    {
        [Test]
        public void Instance_Is_Profile()
        {
            //Arrange
            var type = typeof(Profile);

            //Act
            var map = new ToSuggestion();

            //Assert
            Assert.IsInstanceOf(type, map);
        }

    }
}