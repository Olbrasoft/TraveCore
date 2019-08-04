using System.Collections.Generic;
using NUnit.Framework;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Unit.Tests.Base.Objects.Accommodation
{
    public class AttributeSubtypeTest
    {
        [Test]
        public void Attributes()
        {
            //Arrange
            var attributes = new List<Attribute>();

            //Act
            var subType = new AttributeSubtype
            {
                Attributes = attributes
            };

            //Assert
            Assert.AreSame(attributes, subType.Attributes);
        }
    }
}