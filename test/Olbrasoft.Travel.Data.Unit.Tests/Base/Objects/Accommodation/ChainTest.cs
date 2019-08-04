using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
{
    public class ChainTest
    {
        [Test]
        public void Name()
        {
            //Arrange
            const string name = "Some Name";

            //Act
            var chain = new Chain { Name = name };

            //Assert
            Assert.AreSame(name, chain.Name);
        }
    }
}