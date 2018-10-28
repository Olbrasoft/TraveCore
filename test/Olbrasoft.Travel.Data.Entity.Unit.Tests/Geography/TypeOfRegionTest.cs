using NUnit.Framework;
using NUnit.Framework.Internal;
using Olbrasoft.Travel.Data.Entity.Geography;

namespace Olbrasoft.Travel.Data.Entity.Unit.Tests.Geography
{
    [TestFixture]
    internal class TypeOfRegionTest
    {
        [Test]
        public void Description()
        {
            //Arrange
            const string description = "Description of TypeOfRegion.";
            var typeOfRegion = new TypeOfRegion
            {
                Description = description
            };

            //Act
            var result = typeOfRegion.Description;

            //Assert
            Assert.IsTrue(result == description);
        }
    }
}