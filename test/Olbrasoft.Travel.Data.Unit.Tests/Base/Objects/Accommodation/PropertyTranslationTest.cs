using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
{
    public class PropertyTranslationTest
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