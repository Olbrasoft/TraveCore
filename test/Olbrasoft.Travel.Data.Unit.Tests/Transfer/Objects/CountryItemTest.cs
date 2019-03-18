using NUnit.Framework;
using Olbrasoft.Travel.Data.Transfer;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Unit.Tests.Transfer.Objects
{
    [TestFixture]
    internal class CountryItemTest
    {
        [Test]
        public void Instance_Is_ICountry()
        {
            //Arrange
            var type = typeof(ICountry);

            //Act
            var region = new CountryItem();

            //Assert
            Assert.IsInstanceOf(type, region);
        }

        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Czech Republic";
            var country = new CountryItem
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
            var country = new CountryItem()
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