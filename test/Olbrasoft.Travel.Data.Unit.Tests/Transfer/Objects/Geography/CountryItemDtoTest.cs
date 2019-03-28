using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects.Geography
{
    [TestFixture]
    internal class CountryItemDtoTest
    {
        [Test]
        public void Instance_Is_ICountry()
        {
            //Arrange
            var type = typeof(ICountry);

            //Act
            var region = new CountryItemDto();

            //Assert
            Assert.IsInstanceOf(type, region);
        }

        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Czech Republic";
            var country = new CountryItemDto
            {
                Name = name
            };

            //Act
            var result = country.Name;

            //Assert
            Assert.IsTrue(name == result);
        }

        [Test]
        public void Code()
        {
            //Arrange
            const string code = "CZ";
            var country = new CountryItemDto()
            {
                Code = code
            };

            //Act
            var result = country.Code;

            //Assert
            Assert.IsTrue(code == result);
        }
    }
}