using NUnit.Framework;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Accommodation
{
    public class LocalizedRealEstateTest
    {
        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Some Name";

            //Act
            var realEstate = new PropertyTranslation
            {
                Name = name
            };

            //Assert
            Assert.AreEqual(name, realEstate.Name);
        }
    }
}